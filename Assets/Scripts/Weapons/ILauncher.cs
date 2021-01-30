using UnityEngine;

public interface ILauncher
{

    bool CanShoot();

    void Shoot(Rigidbody projectilePrefab);

}
