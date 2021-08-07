using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button buttonRestart;
    public Button buttonLobby;
    public GameObject GameOver;

    private void Awake()
     {
       
       buttonRestart.onClick.AddListener(ReloadLevel);
       buttonLobby.onClick.AddListener(Lobby);
  
    }
    public void PlayerDied()
    {
       
        gameObject.SetActive(true);
        //SoundManager.Instance.PlayMusic(Sounds.PlayerDeath);
        //GameOver.SetActive(true);
    }
   
    private void ReloadLevel()
    {
        //SceneManager.LoadScene(1);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }
    
    private void Lobby()
    {
        SceneManager.LoadScene(1);
      
    }
}
