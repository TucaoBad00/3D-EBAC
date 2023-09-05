using System;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float startLife = 10;
    public float _currentLife;

    public Action<Health> OnDamage;
    public Action<Health> OnKill;
    public bool destroyOnKill = false;

    public void Awake()
    {
        Init();
    }
    public void Init()
    {
        _currentLife = startLife;
    }
    protected virtual void Kill()
    {
        if(destroyOnKill)
        Destroy(gameObject, 3f);
    }
    
    public void Damage(float f)
    {
        _currentLife -= f;
        if (_currentLife <= 0)
        {
            Kill();
        }
    }
}
