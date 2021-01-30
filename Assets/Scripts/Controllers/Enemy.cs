using UnityEngine;

[RequireComponent(typeof(RigidbodyMotion))]
public class Enemy : MonoBehaviour
{

    /// Inspector
    [SerializeField] private float speed = 10f;

    /// Dependencies
    private RigidbodyMotion rigidbodyMotion;
    private Engine engine;

    private void Awake()
    {
        rigidbodyMotion = GetComponent<RigidbodyMotion>();
        engine = GetComponentInChildren<Engine>();
    }

    private void Start()
    {
        if (engine)
        {
            engine.Ignite();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rigidbodyMotion.Move(Vector3.down, speed);
    }

}
