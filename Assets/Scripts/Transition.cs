using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public string sceneToLoad;
    public GameObject fadeinPanel;
    public GameObject fadeoutPanel;
    public float fadeWait;

    private void Awake()
    {
        if(fadeinPanel != null)
        {
            GameObject panel = Instantiate(fadeinPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            StartCoroutine(FadeCo());
            //SceneManager.LoadScene(sceneToLoad);
        }
    }
    public IEnumerator FadeCo()
    {
        if (fadeoutPanel != null)
        {
            Instantiate(fadeoutPanel, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(fadeWait);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }
}
