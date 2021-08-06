using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    public int health;
    public int numofhearts; //visible hearts in game

    public Image[] hearts; //no. of emptyhearts in screen
    public Image[] emptyhearts;
    public Sprite fullhealth;
    public Sprite emptyheart;
    public PlayerController playerController;

    private void Update()
    {
       

        for (int i=0; i< hearts.Length; i++)
        {
            if (health > numofhearts)
            {
                health = numofhearts;
            }

            hearts[i].sprite = i < health ? fullhealth : emptyheart;
           /* if (i < health)
            {
                hearts[i].sprite = fullhealth;
            } else
            {
                hearts[i].sprite = emptyheart;
            }
           */
           hearts[i].enabled = i < numofhearts ? true : false;

            /* if(i< numofhearts)
             {
                 hearts[i].enabled = true;
             } else
             {
                 hearts[i].enabled = false;
             }*/

        }

    }
    public void ReduceHealth()
    {
        if(health == 1)
        {
            playerController.KillPlayer();
        }
        else
        {
            health -= 1;
        }
    }
}
