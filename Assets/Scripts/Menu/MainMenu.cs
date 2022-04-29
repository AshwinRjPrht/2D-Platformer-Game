using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button buttonPlay;
    private void Awake()
    {
        buttonPlay.onClick.AddListener(PlayGame);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        //SoundManager.Instance.Play(Sounds.ButtonClick);
    }
}

