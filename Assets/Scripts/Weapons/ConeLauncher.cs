﻿using UnityEngine;

public class ConeLauncher : BaseLauncher
{

    [SerializeField]
    private float numProjectiles = 3;

    [SerializeField]
    private float angle = 90;

    public override void Shoot(Rigidbody projectilePrefab)
    {
        float fraction = angle / numProjectiles;

        for (int i = 0; i < numProjectiles; i++)
        {
            float degrees = fraction * i - (angle / 2) + (fraction / 2);
            float radians = Mathf.Deg2Rad * degrees;
            Vector3 direction = /*transform.rotation */ new Vector3(Mathf.Sin(radians), Mathf.Cos(radians), 0f);
            var projectile = Instantiate(projectilePrefab, transform.position, Quaternion.Euler(direction));
            projectile.AddForce(direction.normalized * base.fireForce);
        }
    }

}
