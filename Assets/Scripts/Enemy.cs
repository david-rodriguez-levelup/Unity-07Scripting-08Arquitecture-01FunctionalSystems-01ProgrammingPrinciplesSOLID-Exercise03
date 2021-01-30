using UnityEngine;

[RequireComponent(typeof(PositionSupport))]
public class Enemy : MonoBehaviour
{

    /// Inspector
    [SerializeField] private float speed = 10f;

    /// Dependencies
    private PositionSupport moveRigidbodyPosition;
    private Engine engine;

    private void Awake()
    {
        moveRigidbodyPosition = GetComponent<PositionSupport>();
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
        moveRigidbodyPosition.Move(Vector3.down, speed);
    }

}
