using UnityEngine;

[RequireComponent(typeof(PositionSupport))]
[RequireComponent(typeof(RotationSupport))]
public class Player : MonoBehaviour
{
    /// Inspector
    [SerializeField] private string axisName = "Horizontal";
    [SerializeField] private float speed = 10f;
    [SerializeField] private float angle = 10f;

    /// Dependencies
    private PositionSupport positionSupport;
    private RotationSupport rotationSupport;
    private Engine engine;

    /// Internal
    private float horizontalInput;

    private void Awake()
    {
        positionSupport = GetComponent<PositionSupport>();
        rotationSupport = GetComponent<RotationSupport>();
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
        positionSupport.Move(Vector3.right * horizontalInput, speed);
        rotationSupport.Set(new Vector3(0f, -horizontalInput * angle, 0f));
    }    

}
