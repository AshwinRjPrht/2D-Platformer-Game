﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gameover : MonoBehaviour
{
    public string newScene;
    public Button buttonRestart;
    public Button buttonLobby;
    private void Awake()
    {

        buttonRestart.onClick.AddListener(Wt);
        buttonLobby.onClick.AddListener(Lobby);

    }
    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }
    public void Wt()
    {
        Invoke("ReloadLevel", 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("Player"))
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.buildIndex);
        }
    }
  

   
   
    private void ReloadLevel()
    {
        //SceneManager.LoadScene(1);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);

    }

    private void Lobby()
    {
        SceneManager.LoadScene(0);

    }
}
