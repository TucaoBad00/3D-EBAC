using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheckPoint : MonoBehaviour
{
    public Health health;
    public Action die;
    public void Update()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        health = collision.gameObject.GetComponent<Health>();
    }
   
}
