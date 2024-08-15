using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private GameController gameController;

    public GameObject canvas;
    public GameObject DialogueObj;
    public GameObject pauseMenuObj;
    public GameObject pressETextBox;

    [Header("Pause Menu Objs")]
    public GameObject PauseCharUI;
    public GameObject PauseInvUI;
    public GameObject PauseStatsUI;
    public GameObject PauseNotesUI;

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
        pauseMenuObj.SetActive(false);
        PauseCharUI.SetActive(true);
    }

    public void InventoryUI() {
        pauseMenuObj.SetActive(false);
        PauseInvUI.SetActive(true);
    }

    public void StatsUI() {
        pauseMenuObj.SetActive(false);
        PauseStatsUI.SetActive(true);
    }

    public void NotesUI()
    {
        pauseMenuObj.SetActive(false);
        PauseNotesUI.SetActive(true);
    }
}
