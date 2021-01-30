using UnityEngine;

[RequireComponent(typeof(RigidbodyMotion))]
public class Enemy : MonoBehaviour
{

    [SerializeField] private float speed = 10f;

    private RigidbodyMotion rigidbodyMotion;
    private Engine engine;
    private HealthBehaviour healthBehaviour;

    private void Awake()
    {
        rigidbodyMotion = GetComponent<RigidbodyMotion>();
        engine = GetComponentInChildren<Engine>();
        healthBehaviour = GetComponent<HealthBehaviour>();
    }

    private void OnEnable()
    {
        healthBehaviour.OnChange += OnHealthChange;
    }

    private void OnDisable()
    {
        healthBehaviour.OnChange -= OnHealthChange;
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

    private void OnHealthChange(float currentHealth)
    {
        Debug.Log($"{name} health = " + currentHealth);
    }

}
