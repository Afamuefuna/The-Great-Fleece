using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadLevel : MonoBehaviour
{
    public Image progressBar;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(loadLevelAsync());
    }

    IEnumerator loadLevelAsync()
    {
        yield return null;

        AsyncOperation operation = SceneManager.LoadSceneAsync("Main");

        while(operation.isDone == false)
        {
            progressBar.fillAmount = operation.progress;
            yield return new WaitForEndOfFrame();
        }

    }
}
