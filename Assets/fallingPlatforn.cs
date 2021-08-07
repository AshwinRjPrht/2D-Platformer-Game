using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPlatforn : MonoBehaviour
{
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            Invoke("DropPlatform", 0.25f);
            Destroy(gameObject, 1f);
        }
    }

    void DropPlatform()
    {
        rb.isKinematic = false;
    }
    
        
    
}
