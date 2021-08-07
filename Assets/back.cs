using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class back : MonoBehaviour
{
    public Button buttoncb;

    private void Awake()
    {
        buttoncb.onClick.AddListener(Comeback);
    }

    public void Comeback()
    {
        SceneManager.LoadScene(1);
       
    }
}
