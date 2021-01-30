using UnityEngine;

public class SelfDestroyOnTimeout : MonoBehaviour
{
    /// Inspector
    [SerializeField] float timeout = 5f;

    private void Start()
    {
        Destroy(gameObject, timeout);
    }

}
