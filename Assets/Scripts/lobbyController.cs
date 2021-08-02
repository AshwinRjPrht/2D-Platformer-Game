using UnityEngine;
using UnityEngine.UI;

public class lobbyController : MonoBehaviour
{
    public Button buttonPlay;
    public GameObject LevelSelection;
    private void Awake()
    {
        buttonPlay.onClick.AddListener(PlayGame);
    }
    public void PlayGame(){
        //SceneManager.LoadScene(1);
        SoundManager.Instance.Play(Sounds.ButtonClick);
        LevelSelection.SetActive(true);
    }
}
