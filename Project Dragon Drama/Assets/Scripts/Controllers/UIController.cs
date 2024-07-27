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

    }

    public void StatsUI() {

    }

    public void NotesUI()
    {

    }
}
