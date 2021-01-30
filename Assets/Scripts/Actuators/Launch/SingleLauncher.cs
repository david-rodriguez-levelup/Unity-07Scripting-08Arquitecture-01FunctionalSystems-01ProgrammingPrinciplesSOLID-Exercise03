using UnityEngine;
using UnityEngine.Assertions;

public class SingleLauncher : BaseLauncher
{

    public override void Launch(Rigidbody projectilePrefab)
    {
        //Assert.IsTrue(Time.inFixedTimeStep);

        var projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        projectile.AddForce(projectile.transform.up * base.launchForce);
    }

}
