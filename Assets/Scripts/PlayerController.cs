using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    
    public Animator animator;
    public ScoreController scoreController;
    public GameOverController gameOverController;
 
    public float movementspeed;
    public float jumpForce = 20f;
    private int amountofjumpsleft;
    public int amountofjumps = 1;
    public Transform feet;
    public LayerMask groundLayer;
    public PlayerHealthController Health;

    

    private Rigidbody2D rb2d;
    private void Awake()
    {
        Debug.Log("Player Controller awake");
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        amountofjumpsleft = amountofjumps;
    }
    public void HurtPlayer()
    {
        Health.ReduceHealth();
    }
    public void KillPlayer()
    {
        Debug.Log("Player got killed by chomper");
        //Destroy(gameObject);
        DeathAnimation();
        gameOverController.PlayerDied();
        this.enabled = false;
    }

    private void DeathAnimation()
    {
        animator.SetBool("Died", true);
    }

    public void PickUpKey()
    {
        Debug.Log("Player picked up the key");
        scoreController.IncreaseScore(10);
    }
   
    private void Update()
    {
        if(Input.GetButtonDown("Jump") && isGrounded())
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
     
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        //float crouch = Input.GetAxisRaw("Crouch"); //made a different instruction for this
        //MoveCharacter(horizontal, crouch);
        //PlayMovementAnimation(horizontal, crouch);
        PlayerMovement(horizontal);
        PlayCrouchAnimation();
        PlayJumpAnimation(vertical);
        PlayHorizontalAnimation(horizontal);


    }

    private void PlayerMovement(float horizontal)
    {
        //move character horizontally
        Vector3 position = transform.position;
        position.x += horizontal * movementspeed * Time.deltaTime;
        transform.position = position;
    }

    private void PlayCrouchAnimation()
    {
        animator.SetBool("Crouch", Input.GetKey(KeyCode.LeftControl));
    }
    private void PlayJumpAnimation(float vertical)
    {
        animator.SetBool("Jump", vertical > 0);
    }

    private void PlayHorizontalAnimation(float horizontal)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }

    private void Jump()
    {
        Vector2 movement = new Vector2(rb2d.velocity.x, jumpForce);
        amountofjumpsleft--;
        rb2d.velocity = movement;
    }
    public bool isGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 1f, groundLayer);
        if (groundCheck != null)
        {
            amountofjumpsleft = amountofjumps;
            return true;
        }
        else if(amountofjumpsleft <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    


}

