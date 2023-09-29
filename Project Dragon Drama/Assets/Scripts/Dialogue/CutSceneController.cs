using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CutSceneController : MonoBehaviour
{
    DialogueDictionaries dialogueDictionaries = new DialogueDictionaries();
    CutsceneManager cutsceneManager = new CutsceneManager();
    public TMP_Text dialogueTextBox;
    List<Entry> entryList = new List<Entry>();
    Entry entry;
    public int chapterIdx;
    private int pageIdx;
    public GameObject playerPFP, mg1PFP, mg2PFP, mg3PFP, friendPFP; // UI Images for each character
    public bool cutsceneStart = false;
    // public CharacterControllerBase characterControllerBase;
    
    public GameObject dialogueTextObj;
    public GameObject continueTextBox;
    public GameObject pressETextBox;
    public GameObject nextCutsceneBtn;
    
    public GameObject dialogueOptions;
    public DiagOptions diagOptions;
    bool diagOptReady = false;
    public GameObject skipButton;
    private int diagOptIdx1 = 3, diagOptIdx2 = 0, diagOptIdx3 = 0;

    //public CharacterControllerBase characterControllerBase;
    private CharacterControllerBase characterControllerBase;


    void Awake() {
        //find CharacterControllerBase in scene
        characterControllerBase = GameObject.Find("CharacterController").GetComponent<CharacterControllerBase>();

        //fill dialogue dictionaries in order to access them
        dialogueDictionaries.player.fillBank();
        dialogueDictionaries.meangirl1.fillBank();
        dialogueDictionaries.meangirl2.fillBank();
        dialogueDictionaries.meangirl3.fillBank();
        dialogueDictionaries.friend.fillBank();
        dialogueDictionaries.diagOptions.fillBank1();
        cutsceneManager.cutscene1.fillBank(dialogueDictionaries);
        cutsceneManager.cutscene2.fillBank(dialogueDictionaries);

        chapterIdx = 0;
        pageIdx = 0;

        playerPFP.SetActive(false);
        //continueTextBox.SetActive(false);
        dialogueOptions.SetActive(false);
        skipButton.SetActive(false);
        nextCutsceneBtn.SetActive(false);

        diagOptions = this.GetComponent<DiagOptions>();

        skipButton.SetActive(true);
        changePortriat(cutsceneManager.cutscene1.portraitBank[pageIdx]);
        dialogueTextBox.text = cutsceneManager.cutscene1.diagBank[pageIdx];
    }

    // Update is called once per frame
    void Update()
    {   
        if(characterControllerBase.gossipSearch) {
            nextCutsceneBtn.SetActive(true);
        } else {
            nextCutsceneBtn.SetActive(false);
        }
        
        if(Input.GetKeyDown(KeyCode.E) && cutsceneStart) { // if the player presses E and the cutscene is playing
            if(diagOptReady) { // after the player chooses an option
                diagOptReady = false;
                dialogueTextBox.text = cutsceneManager.cutscene2.diagBank[pageIdx++];
                changePortriat(cutsceneManager.cutscene2.portraitBank[pageIdx]);
            }
            else if(chapterIdx == 0) {
                Cutscene1();
            } else if(chapterIdx == 1) {
                Cutscene2();
            }
        }

        if(diagOptions.ifPressed) { // if the player has chosen an option, change to player potrait and display the chosen option
            Debug.Log("Option Chosen: " + diagOptions.optionChosen);
            diagOptions.ifPressed = false;
            dialogueOptions.SetActive(false);
            diagOptReady = true;
            changePortriat(0);
            dialogueTextBox.text = diagOptions.optionChosen;
            // pageIdx++;
        }
    }

    class Entry {
        public int char1, char2;
        public string text;
        bool isChar1_shaded, isChar2_shaded;

        public void createEntry(int char1, int char2, string text, bool isChar1_shaded, bool isChar2_shaded) {
            this.char1 = char1;
            this.char2 = char2;
            this.text = text;
            this.isChar1_shaded = isChar1_shaded;
            this.isChar2_shaded = isChar2_shaded;
        }
    }

    void changePortriat(int idx) {
        //set pfp
        if(idx == 0) { //player
            playerPFP.SetActive(true);
            mg1PFP.SetActive(false);
            mg2PFP.SetActive(false);
            mg3PFP.SetActive(false);
            friendPFP.SetActive(false);
        } else if (idx == 1) { //mg1
            playerPFP.SetActive(false);
            mg1PFP.SetActive(true);
            mg2PFP.SetActive(false);
            mg3PFP.SetActive(false);
            friendPFP.SetActive(false);
        } else if(idx == 2) { //mg2
            playerPFP.SetActive(false);
            mg1PFP.SetActive(false);
            mg2PFP.SetActive(true);
            mg3PFP.SetActive(false);
            friendPFP.SetActive(false);
        } else if(idx == 3) { //mg3
            playerPFP.SetActive(false);
            mg1PFP.SetActive(false);
            mg2PFP.SetActive(false);
            mg3PFP.SetActive(true);
            friendPFP.SetActive(false);
        } else if(idx == 4) { //friend
            playerPFP.SetActive(false);
            mg1PFP.SetActive(false);
            mg2PFP.SetActive(false);
            mg3PFP.SetActive(false);
            friendPFP.SetActive(true);
        }
    }

    void npcPotriat() { // deactivates all potriats except
        playerPFP.SetActive(false);
        mg1PFP.SetActive(false);
        mg2PFP.SetActive(false);
        mg3PFP.SetActive(false);
        friendPFP.SetActive(false);
    }

    public void NPCtalk(NPCControllerBase npc) {
        if(characterControllerBase.gossipSearch) {
            pressETextBox.SetActive(false);
            dialogueTextObj.SetActive(true);
            npcPotriat();
            Debug.Log("NPC diag:" + npc.gossipText);
            dialogueTextBox.text = npc.gossipText;
            characterControllerBase.endofDialogue = true;
            skipButton.SetActive(false);
        }
    }

    public void SkipCutscene() { //skips to end of cutscene; will need to skip to before the dialogue option
        Debug.Log("Skip Cutscene");
        cutsceneStart = false;
        dialogueTextBox.text = "";
        continueTextBox.SetActive(false);
        characterControllerBase.dialogueTextBox.SetActive(false);
        characterControllerBase.endofDialogue = true;
        pageIdx = 0;
        chapterIdx++;
        characterControllerBase.gossipSearch = true;
    }

    public void StartCutscene() {
        pressETextBox.SetActive(false);
        dialogueTextObj.SetActive(true);
        cutsceneStart = true;
    }

    public void TriggerNextCutscene() {
        characterControllerBase.gossipSearch = false;
        characterControllerBase.endofDialogue = false;

        if (chapterIdx == 1)
        {
            Cutscene2();
        }

        //load next scene in build index
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    private void Cutscene1() {
        if(pageIdx == cutsceneManager.cutscene1.diagBank.Count) { // end of cutscene
            Debug.Log("End of Cutscene");
            characterControllerBase.endofDialogue = true;
            pageIdx = 0;
            continueTextBox.SetActive(true);
            skipButton.SetActive(false);
            chapterIdx++; 
            cutsceneStart = false;
            characterControllerBase.gossipSearch = true; // allow player to talk with other NPCs
        } else { // each E press will go to the next index of the cutscene dialogue bank
            skipButton.SetActive(true);
            changePortriat(cutsceneManager.cutscene1.portraitBank[pageIdx]);
            dialogueTextBox.text = cutsceneManager.cutscene1.diagBank[pageIdx++];
        }
    }

    private void Cutscene2() {
        if(pageIdx == cutsceneManager.cutscene2.diagBank.Count) {
            changePortriat(cutsceneManager.cutscene2.portraitBank[pageIdx]);
            continueTextBox.SetActive(true);
            skipButton.SetActive(false);
            pageIdx = 0;
            chapterIdx++;
            cutsceneStart = false;
            characterControllerBase.gossipSearch = true;
            characterControllerBase.endofDialogue = true;
            Debug.Log("End of Cutscene");
        } else if(pageIdx == diagOptIdx1) { //hard coding when the dialogue option is supposed to start
            dialogueOptions.SetActive(true);
            diagOptions.SetOptions(dialogueDictionaries.diagOptions.dialogueOptionsBank1[0],
                dialogueDictionaries.diagOptions.dialogueOptionsBank1[1], dialogueDictionaries.diagOptions.dialogueOptionsBank1[2]);
            skipButton.SetActive(false);
        } else {
            skipButton.SetActive(true);
            changePortriat(cutsceneManager.cutscene2.portraitBank[pageIdx]);
            dialogueTextBox.text = cutsceneManager.cutscene2.diagBank[pageIdx++];
        }
    }
}

