using System;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public float startLife = 10;
    public float _currentLife;

    public Action<Health> onDamage;
    public Action<Health> OnKill;
    public bool destroyOnKill = false;
    public Animator animator;
    public bool isAlive = true;
    public CheckPoint currentCheck;
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
        if(isAlive) 
            animator.SetBool("Death",true);

        isAlive = false;

        if(destroyOnKill)
            Destroy(gameObject, 1);

        OnKill?.Invoke(this);
        Invoke("Respawn", 2);
        
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
    public void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("CheckPoint"))
        {
            currentCheck = collider.gameObject.GetComponent<CheckPoint>();
        }
    }
    public void Respawn()
    {
        transform.position = currentCheck.transform.position;
        isAlive = true;
        _currentLife = startLife;
        animator.SetTrigger("Idle");
    }
}
