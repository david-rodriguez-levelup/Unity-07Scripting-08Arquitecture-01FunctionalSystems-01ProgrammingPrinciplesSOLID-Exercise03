using UnityEngine;

[RequireComponent(typeof(PositionSupport))]
[RequireComponent(typeof(RotationSupport))]
public class Missile : MonoBehaviour
{

    /// Inspector
    [SerializeField] private LayerMask targetLayerMask;
    [SerializeField] private float speed = 20;
    [SerializeField] private float turnSpeed = 10;

    /// Dependencies
    private PositionSupport positionSupport;
    private RotationSupport rotationSupport;

    /// Internal
    private Transform target;

    private void Awake()
    {
        positionSupport = GetComponent<PositionSupport>();
        rotationSupport = GetComponent<RotationSupport>();
    }

    private void FixedUpdate()
    {
        if (target != null) 
        {
            /*
            Quaternion targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
            rotationSupport.Set(Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime));
            positionSupport.Set(transform.position + transform.up * speed * Time.deltaTime);
            */
            Vector3 toTarget = target.position - transform.position;
            float angle = Mathf.Atan2(toTarget.y, toTarget.x) * Mathf.Rad2Deg - 90f;
            Quaternion quaternion = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, quaternion, speed * Time.deltaTime);
            positionSupport.Set(transform.position + transform.up * speed * Time.deltaTime);
        }        
        else
        {
            FindTarget();
        }
    }

    public void FindTarget()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 10f, targetLayerMask);
        if (colliders.Length > 0)
        {
            float nearestDistance = float.MaxValue;
            Transform nearestTarget = null;
            for (int i = 0; i < colliders.Length; i++)
            {
                float distance = Vector3.Distance(transform.position, colliders[i].transform.position);
                if (distance < nearestDistance)
                {
                    nearestTarget = colliders[i].transform;
                    nearestDistance = distance;                    
                }
            }
            target = nearestTarget;
        } 
        else
        {
            Destroy(gameObject);
        }
    }

}
