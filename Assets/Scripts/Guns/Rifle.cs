using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : GunBase
{
    public float maxBullets;
    public float currentBullets;
    public float reloadDelay;
    public bool reloding;

    protected override IEnumerator ShootCoroutine()
    {
        if (reloding) yield break;
        while (!reloding)
        {
            if (currentBullets > 0)
            {
                Shoot();
                currentBullets--;
                CheckReload();
                yield return new WaitForSeconds(timeBetweenShoot);
            }
        }
    }
    private void CheckReload()
    {
        if (currentBullets == 0) StopShoot();
    }
    private void StartRecharge()
    {
        reloding = true;
    }
    protected IEnumerator Reload()
    {
        float time = 0;
        while(time < reloadDelay)
        {
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
            currentBullets = maxBullets;
            reloding = false;
        }
    }



}
