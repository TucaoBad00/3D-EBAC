using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheckPoint : MonoBehaviour
{
    public int key = 0;
    private bool activedCheck = false;
    public CheckPointManager checkPointManager;
    public void Update()
    {
        
    }
    public void OnTriggerEnter(Collider collision)
    {
        if(!activedCheck && collision.gameObject.CompareTag("Player"))
        {
            check();
        }
    }

    public void check()
    {
        SaveCheckPoint();
    }
    public void SaveCheckPoint()
    {
        /*if(PlayerPrefs.GetInt("CheckPointKey",0)>key)
            PlayerPrefs.SetInt("CheckPointKey",key);*/
        checkPointManager.SaveCheckPoint(key);
    }
}
