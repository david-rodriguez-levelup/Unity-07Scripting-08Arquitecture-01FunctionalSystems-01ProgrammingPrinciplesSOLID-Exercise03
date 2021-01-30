using UnityEngine;

[RequireComponent(typeof(ILauncher))]
public class Weapon : MonoBehaviour
{

    /// Inspector
    [SerializeField] private string fireButton = "Fire1";
    [SerializeField] protected Rigidbody projectilePrefab;
    [SerializeField] private ILauncher launcher;

    private void Awake()
    {
        launcher = GetComponent<ILauncher>();
    }

    private void Update()
    {
        if (Input.GetButtonDown(fireButton))
        {
            TryShoot();
        }
    }

    private void TryShoot()
    {
        if (launcher.CanShoot())
        {
            launcher.Shoot(projectilePrefab);
        }
    }

}
