using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("LoadingScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
