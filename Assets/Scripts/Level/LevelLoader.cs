using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button button;

    public string LevelName;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
    }

    private void onClick()
    {
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);
        //SceneManager.LoadScene(LevelName);
        switch (levelStatus)
        {
            case LevelStatus.Locked:
                Debug.Log("You're Not Worthy");
                break;

            case LevelStatus.Unlocked:
                SoundManager.Instance.Play(Sounds.ButtonClick);
                Debug.Log("Quest is looking forward");
                SceneManager.LoadScene(LevelName);
                break;

            case LevelStatus.Completed:
                Debug.Log("Conquered");
                SceneManager.LoadScene(LevelName);
                break;
        }
    }
}


