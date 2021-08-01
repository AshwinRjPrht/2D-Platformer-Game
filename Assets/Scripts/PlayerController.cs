using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    
    public Animator animator;
    public ScoreController scoreController;
    public GameOverController gameOverController;
 
    public float speed;
    public float jump;
    public float crouch;
    public PlayerHealthController Health;

    

    private Rigidbody2D rb2d;
    private void Awake()
    {
        Debug.Log("Player Controller awake");
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    public void HurtPlayer()
    {
        Health.ReduceHealth();
    }
    public void KillPlayer()
    {
        Debug.Log("Player got killed by chomper");
        //Destroy(gameObject);
        animator.SetBool("Died",true);
        gameOverController.PlayerDied();
        this.enabled = false;
    }

    public void PickUpKey()
    {
        Debug.Log("Player picked up the key");
        scoreController.IncreaseScore(10);
    }
   

    private void Update()
    {
     
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        float crouch = Input.GetAxisRaw("Crouch"); //made a different instruction for this
        MoveCharacter(horizontal, vertical, crouch);
        PlayMovementAnimation(horizontal, vertical, crouch);

    }

    private void MoveCharacter(float horizontal, float vertical, float crouch)
    {
        //move character horizontally
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        //move characer vertically
        if(vertical > 0)
        {
            rb2d.AddForce(new Vector2(2f, jump), ForceMode2D.Force);
        }
        if(crouch > 0)
        {
            rb2d.AddForce(new Vector2(0f, crouch), ForceMode2D.Force);
        }

    }

    private void PlayMovementAnimation(float horizontal, float vertical, float crouch)
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

        animator.SetBool("Jump", vertical > 0);
        animator.SetBool("Crouch", crouch > 0);

    }


}

