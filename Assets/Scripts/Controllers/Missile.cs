using UnityEngine;

[RequireComponent(typeof(RigidbodyMotion))]
[RequireComponent(typeof(FindNearestObjectByLayer))]
public class Missile : MonoBehaviour
{

    [SerializeField] private LayerMask targetLayerMask;
    [SerializeField] private float speed = 20;
    [SerializeField] private float turnSpeed = 10;

    private RigidbodyMotion rigidbodyMotion;
    private FindNearestObjectByLayer findNearestObjectByLayer;

    private Transform target;

    private void Awake()
    {
        rigidbodyMotion = GetComponent<RigidbodyMotion>();
        findNearestObjectByLayer = GetComponent<FindNearestObjectByLayer>();
    }

    private void FixedUpdate()
    {
        if (target != null) 
        {
            rigidbodyMotion.MoveTowards(target, speed, turnSpeed);
        }
        else
        {
            GameObject go = findNearestObjectByLayer.Find();
            if (go != null)
            {
                target = go.transform;  
            }
            else
            {
                // ?
            }
        }
    }

}
