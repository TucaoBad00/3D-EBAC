using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAngle : GunBase
{
    public int amoutPerShoot;
    public float angle;

    public override void Shoot()
    {
        for(int i = 0; i< amoutPerShoot; i++)
        {
            var projectile = Instantiate(prefabProjectile, positionToShoot);
            projectile.transform.localPosition = Vector3.zero;
            projectile.transform.localEulerAngles = Vector3.zero + Vector3.up * (i % 2 == 0 ? angle : -angle);

            projectile.speed = speed;
            projectile.transform.parent = null;
        }
    }
}
