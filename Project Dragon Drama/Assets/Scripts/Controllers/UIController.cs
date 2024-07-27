using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private GameController gameController;
    private GameObject PauseCharUI;
    private GameObject PauseInvUI;
    private GameObject PauseStatsUI;
    private GameObject PauseNotesUI;

    public GameObject canvas;
    public GameObject DialogueObj;
    public GameObject pauseMenuObj;
    public GameObject pressETextBox;

    private void Awake() {
        gameController = GetComponentInParent<GameController>();
    }

    public void Pause() {
        pauseMenuObj.SetActive(true);
    }

    public void Resume() {
        pauseMenuObj.SetActive(false);
    }

    public void CharacterInfoUI() {

    }

    public void InventoryUI() {

    }

    public void StatsUI() {

    }

    public void NotesUI()
    {

    }
}
