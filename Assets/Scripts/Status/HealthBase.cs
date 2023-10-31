using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour, IDamageable
{
    public float startLife = 10;
    public float _currentLife;
    public bool isAlive = true;
    public Action<HealthBase> onDamage;
    public Action<HealthBase> OnKill;
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
        isAlive = false;
        OnKill?.Invoke(this);

    }
    public void OnDamage(float f)
    {
        if (isAlive)
        {
            _currentLife -= f;
            if (_currentLife <= 0)
            {
                Kill();
            }
            onDamage?.Invoke(this);
        }
    }
    public void IDamage(float damage)
    {
        OnDamage(damage);
    }
    public void ResetLife()
    {
        _currentLife = startLife;
    }
}
