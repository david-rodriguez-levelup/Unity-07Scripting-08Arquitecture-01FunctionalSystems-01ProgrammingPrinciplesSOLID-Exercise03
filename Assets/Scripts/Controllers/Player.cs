using UnityEngine;

[RequireComponent(typeof(RigidbodyMotion))]
public class Player : MonoBehaviour
{
    /// Inspector
    [SerializeField] private string axisName = "Horizontal";
    [SerializeField] private float speed = 10f;
    [SerializeField] private float angle = 10f;

    /// Dependencies
    private RigidbodyMotion rigidbodyMotion;
    private Engine engine;

    /// Internal
    private float horizontalInput;

    private void Awake()
    {
        rigidbodyMotion = GetComponent<RigidbodyMotion>();
        engine = GetComponentInChildren<Engine>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis(axisName);
    }

    private void FixedUpdate()
    {
        if (horizontalInput != 0)
        {
            Move();
            engine.Ignite();
        }
        else
        {
            engine.Rest();
        }
    }

    private void Move()
    {
        rigidbodyMotion.Move(Vector3.right * horizontalInput, speed);
        rigidbodyMotion.Rotate(new Vector3(0f, -horizontalInput * angle, 0f));
    }    

}
