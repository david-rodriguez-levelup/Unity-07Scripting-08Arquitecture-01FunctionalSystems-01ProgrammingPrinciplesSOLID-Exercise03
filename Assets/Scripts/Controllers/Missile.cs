using UnityEngine;

[RequireComponent(typeof(RigidbodyMotion))]
[RequireComponent(typeof(LayerBasedNearestObjectFinder))]
[RequireComponent(typeof(LayerBasedCollisionDetector))]
[RequireComponent(typeof(DamageInflictor))]
public class Missile : MonoBehaviour
{

    [SerializeField] private LayerMask targetLayerMask;
    [SerializeField] private float speed = 20;
    [SerializeField] private float turnSpeed = 10;

    private RigidbodyMotion rigidbodyMotion;
    private LayerBasedNearestObjectFinder nearestEnemyFinder;
    private LayerBasedCollisionDetector enemyCollisionDetector;
    private DamageInflictor damageInflictor;


    private Transform target;

    private void Awake()
    {
        rigidbodyMotion = GetComponent<RigidbodyMotion>();
        nearestEnemyFinder = GetComponent<LayerBasedNearestObjectFinder>();
        enemyCollisionDetector = GetComponent<LayerBasedCollisionDetector>();
        damageInflictor = GetComponent<DamageInflictor>();
    }

    private void OnEnable()
    {
        enemyCollisionDetector.OnEnter += OnCollisionDetected;
    }

    private void FixedUpdate()
    {
        if (target != null) 
        {
            rigidbodyMotion.MoveTowards(target, speed, turnSpeed);
        }
        else
        {
            GameObject go = nearestEnemyFinder.Find();
            if (go != null)
            {
                target = go.transform;  
            }
            else
            {
                //rigidbodyMotion.Rotate(Vector3.up); // - FALTA ESTO!
                rigidbodyMotion.Move(Vector3.up, speed);
            }
        }
    }

    private void OnCollisionDetected(Collision collision)
    {
        HealthBehaviour healthBehaviour = collision.gameObject.GetComponent<HealthBehaviour>();
        if (healthBehaviour != null)
        {
            damageInflictor.InflictDamage(healthBehaviour);
            Destroy(gameObject);
        }
    }

}
