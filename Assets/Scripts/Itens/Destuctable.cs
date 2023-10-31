using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
public class Destuctable : MonoBehaviour
{
    public HealthBase health;
    public float shakeDuration = .1f;
    public int shakeForce = 1;

    public int dropCoinsAmount = 10;
    public GameObject coinPrefab;
    public Transform dropPosition;
    private void OnValidate()
    {
        if (health == null) health = GetComponent<HealthBase>();
    }
    private void Awake()
    {
        OnValidate();
        health.onDamage += OnDamage;
    }
    private void OnDamage(HealthBase h)
    {
        transform.DOShakeScale(shakeDuration, Vector3.up, shakeForce);
        DropCoins();
    }
    private void DropCoins()
    {
        var i = Instantiate(coinPrefab);
        i.transform.position = dropPosition.position;
    }
}
