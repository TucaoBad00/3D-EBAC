using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skin;
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
    [SerializeField]private SkinChanger skinChanger;
    public KeyCode interact = KeyCode.E;
    private bool isWalking;
    private float vSpeed = 0f;
    public List<ParticleSystem> particles;


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
                particles[0].Play();
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
    public void ChangeSpeed(float speed, float duration)
    {
        StartCoroutine(ChangeSpeedCoroutine(speed,duration));
    }
    IEnumerator ChangeSpeedCoroutine(float localSpeed, float duration)
    {
        var defaultSpeed = speed;
        speed = localSpeed;
        yield return new WaitForSeconds(duration);
        speed = defaultSpeed;
    }
    public void ChangeTexture(Skin.SkinSetup skinSetup, float duration)
    {
        StartCoroutine(ChangeTextureCoroutine(skinSetup, duration));
    }
    IEnumerator ChangeTextureCoroutine(Skin.SkinSetup skinSetup, float duration)
    {
        skinChanger.ChangeTexture(skinSetup);
        yield return new WaitForSeconds(duration);
        skinChanger.ResetTexture();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Enemy"))
        {
            var idamageable = collision.gameObject.GetComponent<IDamageable>();
            if(doDamage)
            {
                idamageable.IDamage(2);
            }
        }
    }
    public void TouchDamage(float duration)
    {
        StartCoroutine(TouchDamageCoroutine(duration));
    }
    private bool doDamage;
    IEnumerator TouchDamageCoroutine(float duration)
    {
        doDamage = true;
        yield return new WaitForSeconds(duration);
        doDamage = false;
    }
}
