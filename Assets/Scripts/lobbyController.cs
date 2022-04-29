using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lobbyController : MonoBehaviour
{
    public Button buttonLevels;
    public Button buttonPlay;
    public Button buttonQuit;
    public GameObject LevelSelection;
    private void Awake()
    {
        buttonPlay.onClick.AddListener(StartG);
        buttonLevels.onClick.AddListener(PlayGame);
        buttonQuit.onClick.AddListener(Quit);
    }
    public void PlayGame(){
        //SceneManager.LoadScene(1);
        SoundManager.Instance.Play(Sounds.ButtonClick);
        LevelSelection.SetActive(true);
    }

    public void StartG()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
