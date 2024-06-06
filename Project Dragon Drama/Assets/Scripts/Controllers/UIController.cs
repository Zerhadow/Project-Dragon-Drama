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

    private void Awake() {
        gameController = GetComponentInParent<GameController>();
    }
}
