using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    AudioManager audioManager;
    AudioSource titleSource;

    void Awake() {
        if(SceneManager.GetActiveScene().name == "Title Menu") {
            audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
            if (audioManager == null) {
                Debug.LogError("No audio manager found in the scene.");
            }
            
            titleSource = GameObject.Find("TitleTrack").GetComponent<AudioSource>();
            StartCoroutine(AudioManager.StartFade(titleSource, 3f, 1f));
        }
    }

    public void PlayGame() {
        titleSource.Stop();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame() {
        //disable if on WebGL build or have go to static picture
        Debug.Log("Quit");
        Application.Quit();
    }

    public void BackToMenu() {
        SceneManager.LoadScene("Title Menu");
    }
}
