using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombactController : MonoBehaviour
{
    [SerializeField]
    private bool combatEnabled;
    [SerializeField]
    private float inputTimer, attack1Radius, attack1Damage;
    [SerializeField]
    private Transform attackHitBoxPos;
    [SerializeField]
    private LayerMask whatIsDamageable;

    private bool gotInput, isAttacking, isFirstAttack;

    private float lastInputTime = Mathf.NegativeInfinity;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("CanAttack", combatEnabled);
    }

    private void Update()
    {
        CheckCombatInput();
        CheckAtacks();
    }
    private void CheckCombatInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (combatEnabled)
            {
                //Attack combat
                gotInput = true;
                lastInputTime = Time.time;
            }
        }
    }

    private void CheckAtacks()
    {
        if (gotInput)
        {
            if (!isAttacking)
            {
                gotInput = false;
                isAttacking = true;
                isFirstAttack = !isFirstAttack;
                anim.SetBool("Attack1", true);
                anim.SetBool("FirstAttack", isFirstAttack);
                anim.SetBool("Attacking", isAttacking);
            }
        }
        if(Time.time >= lastInputTime + inputTimer)
        {
            //wait for new input
            gotInput = false;
        }
    }

    private void CheckAttackHitBox()
    {
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackHitBoxPos.position, attack1Radius, whatIsDamageable);

        foreach(Collider2D collider in detectedObjects)
        {
            collider.transform.SendMessage("Damage", attack1Damage);
            //Instantiate hit particle
        }
    }

    private void FinishAttack1()
    {
        isAttacking = false;
        anim.SetBool("Attacking", isAttacking);
        anim.SetBool("Attack1", false);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackHitBoxPos.position, attack1Radius);
    }

}
