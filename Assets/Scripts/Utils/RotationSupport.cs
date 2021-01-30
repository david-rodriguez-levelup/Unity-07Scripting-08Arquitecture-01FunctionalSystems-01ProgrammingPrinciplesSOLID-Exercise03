using UnityEngine;

public class RotationSupport : MonoBehaviour
{

    // Internal
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>(); // Could be null.
    }

    public void Move(Vector3 eulerRotation, float speed)
    {
        Quaternion deltaRotation = Quaternion.Euler(eulerRotation * speed * Time.deltaTime);
        if (_rigidbody)
        {
            _rigidbody.MoveRotation(_rigidbody.rotation * deltaRotation);
        }
        else
        {
            transform.rotation = transform.rotation * deltaRotation;
        }
    }

    public void Set(Quaternion rotation)
    {
        if (_rigidbody)
        {
            _rigidbody.rotation = rotation;
        }
        else
        {
            transform.rotation = rotation;
        }
    }

    public void Set(Vector3 eulerRotation)
    {
        if (_rigidbody)
        {
            _rigidbody.rotation = Quaternion.Euler(eulerRotation);
        }
        else
        {
            transform.rotation = Quaternion.Euler(eulerRotation);
        }
    }

}
