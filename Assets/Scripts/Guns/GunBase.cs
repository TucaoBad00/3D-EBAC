using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase prefabProjectile;
    public Transform positionToShoot;
    public float timeBetweenShoot;
    public float speed;
    public ParticleSystem particle;
    private Coroutine _currentCoroutine;
    protected virtual IEnumerator ShootCoroutine()
    {
        while(true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }
    public void StartShoot()
    {
        StopShoot();
        _currentCoroutine = StartCoroutine(ShootCoroutine());
    }
    public void StopShoot()
    {
            if (_currentCoroutine != null)
                StopCoroutine(_currentCoroutine);

    }
    public virtual void Shoot()
    {
        var projectile = Instantiate(prefabProjectile);
        if(particle!=null)particle.Play();
        projectile.transform.position = positionToShoot.position;
        projectile.transform.rotation = positionToShoot.rotation;
        projectile.speed = speed;
    }
}
