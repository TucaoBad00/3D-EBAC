using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.StateMachine;
public class PlayerMoviment : MonoBehaviour
{
    public new Rigidbody rigidbody;
    public float speed;
    public StateMachine<MovimentStates> stateMachine = new StateMachine<MovimentStates>();
    public bool flying;
    public enum MovimentStates
    {
        MOVING,
        IDLE,
        JUMPING,
        DEAD
    }
    public void Awake()
    {
        stateMachine.Init();
    }
    public void Start()
    {
        rigidbody.GetComponent<Rigidbody>();
        stateMachine.RegisterState(MovimentStates.MOVING,new Moviment());
        //stateMachine.SwitchState(MovimentStates.IDLE);


    }
    public void Update()
    {
        
        stateMachine.Update();
        StateController();
    }
    public void StateController()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) stateMachine.SwitchState(MovimentStates.MOVING);
        if (flying) stateMachine.SwitchState(MovimentStates.JUMPING);

    }
    public void OnCollisionStay(Collision collision)
    {
        
    }
}
public class Moviment : StateBase
{
    public CharacterController characterController;
    PlayerMoviment player;
    public override void OnStateEnter(params object[] objs)
    {
        base.OnStateEnter(player);

    }
    public override void OnStateStay()
    {
        base.OnStateStay();
        var move = transform.forward * Input.GetAxis("Vertical") * player.speed;
    }
}
public class Jump : StateBase
{

}
public class Idle : StateBase
{
    
}
public class Dead : StateBase
{

}
