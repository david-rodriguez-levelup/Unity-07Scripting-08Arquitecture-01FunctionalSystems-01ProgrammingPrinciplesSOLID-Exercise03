using UnityEngine;

public class SingleLauncher : BaseLauncher
{

    public override void Shoot(Rigidbody projectilePrefab)
    {
        var projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        projectile.AddForce(projectile.transform.up * base.fireForce);
    }

}
