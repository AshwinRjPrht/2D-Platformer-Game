using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
  
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("Player"))
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.buildIndex);
           
        }
    }
  
}
