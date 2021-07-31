using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float distance;
    private bool movright = true;
    public Transform groundDetection;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.HurtPlayer();

        }
    }
    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == false)
        {
            if(movright == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movright = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movright = true;
            }
        }
    }
   
    /*void Update()
    {
        if (movright)
        {
            transform.Translate(3 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(3, 3);
        }
        else
        {
            transform.Translate(-3 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(-3, 3);
        }
    }
    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("turn"))
        {
            if (movright)
            {
                movright = false;
            }
            else
            {
                movright = true;
            }
        }
      
    }*/
}
