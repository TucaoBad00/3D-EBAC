using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("MOVIMENTO")]
    public float speed;
    public float runSpeed;
    public float rotateSpeed;
    public float gravity = 9.8f;
    public float jumpSpeed;
    public CharacterController characterController;
    public Animator animator;
    public CheckPointManager checkPointManager;
    public Health health;
    public KeyCode interact = KeyCode.E;
    private bool isWalking;
    private float vSpeed = 0f;

    private void Awake()
    {
        OnValidate();
    }
    private void OnValidate()
    {
        
    }


    void Update()
    {
        if(health.isAlive)
        {
            Move();
        }

    }
    public void Move()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime, 0);
        var speedVector = transform.forward * Input.GetAxis("Vertical") * speed;
        //JUMP
        if (characterController.isGrounded)
        {
            vSpeed = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                vSpeed = jumpSpeed;
            }
        }
        //WALKING

        isWalking = Input.GetAxis("Vertical") != 0;
        if (isWalking)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speedVector *= runSpeed;
                animator.speed = runSpeed;
            }
            else
            {
                animator.speed = 1f;
            }
        }

        vSpeed -= gravity * Time.deltaTime;
        speedVector.y = vSpeed;
        characterController.Move(speedVector * Time.deltaTime);
        //ANIMATION
        animator.SetBool("Run", Input.GetAxis("Vertical") != 0);

    }
    [NaughtyAttributes.Button]
    public void Respawn()
    {
        if(checkPointManager.HasCheckPoint())
        {
            transform.position = checkPointManager.GetPositionFromLastCheckPoint();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(Input.GetKeyDown(interact))
        {
            var iinteractable = other.GetComponent<IInteractable>();
            if(iinteractable!=null)
            {
                iinteractable.IInteract();
            }
        }

    }
}
