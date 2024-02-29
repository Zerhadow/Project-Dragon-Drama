using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public GameObject canvas;
    public GameObject DialogueObj;
    public GameObject pauseMenuObj;
    [Header("Dialogue Node Variables")]
    public TMP_Text nameBoxTxt;
    public TMP_Text bodyTxt;
    [Header("Branch Node Object & Text Variables")]
    public GameObject dialogueOptionsObj;
    public GameObject options3GameObj;
    public TMP_Text option1;
    public TMP_Text option2;
    public TMP_Text option3;
}
