using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBase : MonoBehaviour
{
    public virtual void OnStateEnter(params object[] objs)
    {

    }
    public virtual void OnStateStay()
    {

    }
    public virtual void OnStateExit()
    {

    }
}

