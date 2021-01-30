using UnityEngine;

public abstract class BaseLauncher : MonoBehaviour, ILauncher
{
    [SerializeField]
    protected float fireForce;

    public virtual bool CanShoot()
    {
        return true;
    }

    public abstract void Shoot(Rigidbody projectilePrefab);

}
