using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private enum State
    {
        Walking,
        KnockBack,
        Dead
    }
    private State currentState;
    [SerializeField]
    private float groundCheckDistance, movementSpeed, maxHealth, knockbackDuration;
    [SerializeField]
    private Transform groundcheck;
    [SerializeField]
    private LayerMask whatIsGround;
    [SerializeField]
    private Vector2 knockbackSpeed;
    private float currentHealth, knockbackStartTime;
    private int FacingDirection, DamageDirection;
    private RaycastHit2D groundDetected;
    private GameObject alive;
    private Rigidbody2D aliveRB;
    private Vector2 movement;
    private Animator aliveAnim;
    
    
    private void Start()
    {
        alive = transform.Find("Alive").gameObject;
        aliveRB = alive.GetComponent<Rigidbody2D>();
        aliveAnim = alive.GetComponent<Animator>();

        currentHealth = maxHealth;
        FacingDirection = 1;
    }

   


    private void Update()
    {
        switch (currentState)
        {
            case State.Walking:
                UpdateWalkingState();
                break;
            case State.KnockBack:
                UpdateKnockBackState();
                break;
            case State.Dead:
                UpdateDeadState();
                break;

        }
    }
    //------------------------WALKING STATE-----------------------------------
    private void EnterWalkingState()
    {

    }

    private void UpdateWalkingState()
    {
        groundDetected = Physics2D.Raycast(groundcheck.position, Vector2.down, groundCheckDistance, whatIsGround);
        if (groundDetected.collider == false)
        {
            Flip();//flip
        }
        else
        {
            movement.Set(movementSpeed * FacingDirection, aliveRB.velocity.y);
            aliveRB.velocity = movement;               //move
        }
    }
    private void ExitWalkingState()
    {

    }

    //--------------------------KNOCKBACK STATE-------------------------------
    private void EnterKnockBackState()
    {
        knockbackStartTime = Time.time;
        movement.Set(knockbackSpeed.x * DamageDirection, knockbackSpeed.y);
        aliveRB.velocity = movement;
        aliveAnim.SetBool("KnockBack", true);
    }

    private void UpdateKnockBackState()
    {
        if( Time.time >= knockbackStartTime + knockbackDuration)
        {
            SwitchState(State.Walking);
        }
    }

    private void ExitKnockBackState()
    {
        aliveAnim.SetBool("KnockBack", false);
    }
    //---------------------------DEAD STATE-----------------------------------
    private void EnterDeadState()
    {
        Destroy(gameObject);
    }

    private void UpdateDeadState()
    {

    }
    private void ExitDeadState()
    {

    }
    //---------------------------OTHER FUNCTIONS------------------------------
    private void Damage(float[] attackDetails)
    {
        currentHealth -= attackDetails[0];

        if(attackDetails[1] > alive.transform.position.x)
        {
            DamageDirection = -1;
        }
        else
        {
            DamageDirection = 1;
        }

        //Hit Particle
        if(currentHealth > 0.0f)
        {
            SwitchState(State.KnockBack);
        }
        else if(currentHealth<= 0.0f)
        {
            SwitchState(State.Dead);
        }

    }
    private void Flip()
    {
        FacingDirection *= -1;
        alive.transform.Rotate(0.0f, 180.0f,0.0f);
    }
    private void SwitchState(State state)
    {
        switch (currentState)
        {
            case State.Walking:
                ExitWalkingState();
                break;
            case State.KnockBack:
                ExitKnockBackState();
                break;
            case State.Dead:
                ExitDeadState();
                break;
        }
        switch (state)
        {
            case State.Walking:
                EnterWalkingState();
                break;
            case State.KnockBack:
                EnterKnockBackState();
                break;
            case State.Dead:
                EnterDeadState();
                break;
        }
        currentState = state;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundcheck.position, new Vector2(groundcheck.position.x, groundcheck.position.y - groundCheckDistance));
      

    }


}
