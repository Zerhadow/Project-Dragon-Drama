using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndScenes : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("Title Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
