using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    private GameController gameController;
    public GameObject canvas;
    public GameObject DialogueObj;
    public GameObject pauseMenuObj;
    public GameObject pressETextBox;

    [Header("DialogueNode Variables")]
    public TMP_Text nameBoxTxt;
    public TMP_Text bodyTxt;

    [Header("BranchNode Object Variables")]
    public GameObject dialogueOptionsObj;
    public GameObject btnsObj;
    
    [Header("BranchNode Text Variables")]
    public TMP_Text option1;
    public TMP_Text option2;
    public TMP_Text option3;

    private void Awake() {
        gameController = GetComponentInParent<GameController>();
    }
}
