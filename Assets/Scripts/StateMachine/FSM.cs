using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.StateMachine;
public class FSM : MonoBehaviour
{
    public enum ExampleEnum
    {
        STATE_ONE,
        STATE_TWO,
        STATE_THREE
    }

    public StateMachine<ExampleEnum> stateMachine;
    private void Start()
    {
        stateMachine = new StateMachine<ExampleEnum>();
        stateMachine.Init();
        stateMachine.RegisterState(ExampleEnum.STATE_ONE, new StateBase());
        stateMachine.RegisterState(ExampleEnum.STATE_TWO, new StateBase());
    }
}
