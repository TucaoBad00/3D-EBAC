using System;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageble
{
    public float startLife = 10;
    public float _currentLife;

    public Action<Health> onDamage;
    public Action<Health> OnKill;
    public bool destroyOnKill = false;
    public Animator animator;
    private bool isAlive = true;
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
        if(isAlive) animator.SetBool("Death",true);
        isAlive = false;

        if(destroyOnKill)
            Destroy(gameObject, 1);
        OnKill?.Invoke(this);
    }
    
    public void OnDamage(float f)
    {
        _currentLife -= f;
        if (_currentLife <= 0)
        {
            Kill();
        }
        onDamage?.Invoke(this);
    }

    public void IDamage(float damage)
    {
        OnDamage(damage);
    }
}
