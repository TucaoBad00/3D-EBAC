using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityShoot : PlayerAbilityBase
{
    public InputAction shoot;
    public List<GunBase> gun;
    public int currentGun = 0;

    protected override void Init()
    {

        base.Init();
        gun[currentGun].gameObject.SetActive(true);
        inputs.Gameplay.Shoot.performed += cts => StartShoot();
        inputs.Gameplay.Shoot.canceled += cts => CancelShoot();
        inputs.Gameplay.ChangeGun.performed += cts => ChangeGun();
    }
    private void ChangeGun()
    {
        if(currentGun == gun.Count-1)
        {
            currentGun = 0;
            gun[currentGun].gameObject.SetActive(true);
            gun[gun.Count - 1].gameObject.SetActive(false);
        }
        else
        {
            currentGun++;
            gun[currentGun].gameObject.SetActive(true);
            if (currentGun == 0)
            {
                gun[gun.Count-1].gameObject.SetActive(false);
            }
            else
            {
                gun[currentGun - 1].gameObject.SetActive(false);
            }
        }       
    }


    private void StartShoot()
    {
        gun[currentGun].StartShoot();

    }
    private void CancelShoot()
    {
        gun[currentGun].StopShoot();
    }
}
