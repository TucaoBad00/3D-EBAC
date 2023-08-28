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


    private bool isWalking;
    private float vSpeed = 0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal")*rotateSpeed*Time.deltaTime, 0);
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
                
            }
        }
        animator.speed *= runSpeed;
        vSpeed -= gravity * Time.deltaTime;
        speedVector.y = vSpeed;
        characterController.Move(speedVector * Time.deltaTime);
        //ANIMATION
        animator.SetBool("Run", Input.GetAxis("Vertical") != 0);

    }
}
