using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    AudioManager audioManager;
    AudioSource titleSource;
    string titleName = "Title_b1"; // wtv the title scene is called

    void Awake() {
        if(SceneManager.GetActiveScene().name == titleName) {
            audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
            
            if (audioManager == null) {
                Debug.LogError("No audio manager found in the scene.");
            }
            
            audioManager.PlayTitle("title track");
        }
    }

    public void PlayGame() {
        audioManager.StopTitle();
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
