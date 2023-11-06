using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;

public class CheckPointManager : Singleton<CheckPointManager>
{
    public int lastCheckPoint = 0;
    public List<CheckPoint> checkPoints;
    public bool HasCheckPoint()
    {
        return lastCheckPoint > 0;
    }
    public void SaveCheckPoint(int i)
    {
        if(i > lastCheckPoint)
        {
            lastCheckPoint = i;
        }
    }

    public Vector3 GetPositionFromLastCheckPoint()
    {
        var checkPoint = checkPoints.Find(i => i.key == lastCheckPoint);
        return checkPoint.transform.position;
    }
}
