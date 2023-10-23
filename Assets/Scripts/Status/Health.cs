using System;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public float startLife = 10;
    public float _currentLife;
    public bool isAlive = true;
    public Player player;

    public Action<Health> onDamage;
    public Action<Health> OnKill;
    public Action<Health> onRevive;

    public bool destroyOnKill = false;

    public Animator animator;

    public GameObject currentCheck;
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
        animator.SetBool("Death",true);
        isAlive = false;
        if(destroyOnKill)
            Destroy(gameObject, 1);

        OnKill?.Invoke(this);
        Invoke("Respawn", 2.5f);
        
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

    public void Respawn()
    {
        onRevive?.Invoke(this);
        _currentLife = startLife;
        animator.SetTrigger("Idle");
        player.Respawn();
        isAlive = true;
    }
}
