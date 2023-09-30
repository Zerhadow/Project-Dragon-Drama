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
    public int pageIdx;
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
    private int diagOptIdx1 = 100, diagOptIdx2 = 0, diagOptIdx3 = 0;

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
        dialogueDictionaries.narrator.fillBank();
        dialogueDictionaries.teacher.fillBank();
        dialogueDictionaries.keyStudent.fillBank();
        cutsceneManager.cutscene1.fillBank(dialogueDictionaries);
        cutsceneManager.cutscene2.fillBank(dialogueDictionaries);
        cutsceneManager.cutscene3.fillBank(dialogueDictionaries);
        cutsceneManager.cutscene4.fillBank(dialogueDictionaries);
        cutsceneManager.cutscene5.fillBank(dialogueDictionaries);
        cutsceneManager.cutscene6.fillBank(dialogueDictionaries);
        cutsceneManager.cutscene7.fillBank(dialogueDictionaries);
        cutsceneManager.cutscene8.fillBank(dialogueDictionaries);

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
                Debug.Log("Cutscene 1");
                Cutscene1();
            } else if(chapterIdx == 1) {
                Debug.Log("Cutscene 2");
                Cutscene2();
            } else if(chapterIdx == 2) {
                Debug.Log("Cutscene 3");
                Cutscene3();
            } else if(chapterIdx == 3) {
                Debug.Log("Cutscene 4");
                Cutscene4();
            } else if(chapterIdx == 4) {
                Debug.Log("Cutscene 5");
                Cutscene5();
            } else if(chapterIdx == 5) {
                Debug.Log("Cutscene 6");
                Cutscene6();
            } else if(chapterIdx == 6) {
                Debug.Log("Cutscene 7");
                Cutscene7();
            } else if(chapterIdx == 7) {
                Debug.Log("Cutscene 8");
                Cutscene8();
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
        } else {
            npcPotriat();
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
        pressETextBox.SetActive(false);
        dialogueTextObj.SetActive(true);
        npcPotriat();
        Debug.Log("NPC diag:" + npc.gossipText);
        dialogueTextBox.text = npc.gossipText;
        characterControllerBase.NPCTalking = false;
        skipButton.SetActive(false);
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
            LoadCutscene2();
        } else if(chapterIdx == 2) {
            LoadCutscene3();
        } else if(chapterIdx == 3) {
            LoadCutscene4();
        } else if(chapterIdx == 4) {
            LoadCutscene5();
        } else if(chapterIdx == 5) {
            LoadCutscene6();
        } else if(chapterIdx == 6) {
            LoadCutscene7();
        } else {
            // Debug.Log("End of Cutscenes");
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

    private void LoadCutscene2() {
        // Debug.Log("Load Cutscene 2");
        skipButton.SetActive(true);
        changePortriat(cutsceneManager.cutscene2.portraitBank[pageIdx]);
        dialogueTextBox.text = cutsceneManager.cutscene2.diagBank[0];
    }

    private void Cutscene2() {
        if(pageIdx == cutsceneManager.cutscene2.diagBank.Count) {
            Debug.Log("End of Cutscene");
            characterControllerBase.endofDialogue = true;
            continueTextBox.SetActive(true);
            skipButton.SetActive(false);
            pageIdx = 0;
            chapterIdx++;
            cutsceneStart = false;
            characterControllerBase.gossipSearch = true;
        } else {
            skipButton.SetActive(true);
            changePortriat(cutsceneManager.cutscene2.portraitBank[pageIdx]);
            dialogueTextBox.text = cutsceneManager.cutscene2.diagBank[pageIdx++];
        }
    }

    private void LoadCutscene3() {
        Debug.Log("Load Cutscene 3");
        skipButton.SetActive(true);
        changePortriat(cutsceneManager.cutscene3.portraitBank[pageIdx]);
        dialogueTextBox.text = cutsceneManager.cutscene3.diagBank[0];
    }
    
    private void Cutscene3() {
        if(pageIdx == cutsceneManager.cutscene3.diagBank.Count) {
            Debug.Log("End of Cutscene");
            characterControllerBase.endofDialogue = true;
            continueTextBox.SetActive(true);
            skipButton.SetActive(false);
            pageIdx = 0;
            chapterIdx++;
            cutsceneStart = false;
            characterControllerBase.gossipSearch = true;
        } else {
            skipButton.SetActive(true);
            changePortriat(cutsceneManager.cutscene3.portraitBank[pageIdx]);
            dialogueTextBox.text = cutsceneManager.cutscene3.diagBank[pageIdx++];
        }
    }

    private void LoadCutscene4() {
        Debug.Log("Load Cutscene 4");
        skipButton.SetActive(true);
        changePortriat(cutsceneManager.cutscene4.portraitBank[pageIdx]);
        dialogueTextBox.text = cutsceneManager.cutscene4.diagBank[0];
    }
    private void Cutscene4() {
        if(pageIdx == cutsceneManager.cutscene4.diagBank.Count) {
            Debug.Log("End of Cutscene");
            characterControllerBase.endofDialogue = true;
            continueTextBox.SetActive(true);
            skipButton.SetActive(false);
            pageIdx = 0;
            chapterIdx++;
            cutsceneStart = false;
            characterControllerBase.gossipSearch = true;
        } else {
            skipButton.SetActive(true);
            changePortriat(cutsceneManager.cutscene4.portraitBank[pageIdx]);
            dialogueTextBox.text = cutsceneManager.cutscene4.diagBank[pageIdx++];
        }
    }

    private void LoadCutscene5() {
        Debug.Log("Load Cutscene 5");
        skipButton.SetActive(true);
        changePortriat(cutsceneManager.cutscene5.portraitBank[pageIdx]);
        dialogueTextBox.text = cutsceneManager.cutscene5.diagBank[0];
    }

    private void Cutscene5() {
        if(pageIdx == cutsceneManager.cutscene5.diagBank.Count) {
            Debug.Log("End of Cutscene");
            characterControllerBase.endofDialogue = true;
            continueTextBox.SetActive(true);
            skipButton.SetActive(false);
            pageIdx = 0;
            chapterIdx++;
            cutsceneStart = false;
            characterControllerBase.gossipSearch = true;
        } else {
            skipButton.SetActive(true);
            changePortriat(cutsceneManager.cutscene5.portraitBank[pageIdx]);
            dialogueTextBox.text = cutsceneManager.cutscene5.diagBank[pageIdx++];
        }
    }

    private void LoadCutscene6() {
        Debug.Log("Load Cutscene 6");
        skipButton.SetActive(true);
        changePortriat(cutsceneManager.cutscene6.portraitBank[pageIdx]);
        dialogueTextBox.text = cutsceneManager.cutscene6.diagBank[0];
    }

    private void Cutscene6() {
        if(pageIdx == cutsceneManager.cutscene6.diagBank.Count) {
            Debug.Log("End of Cutscene");
            characterControllerBase.endofDialogue = true;
            continueTextBox.SetActive(true);
            skipButton.SetActive(false);
            pageIdx = 0;
            chapterIdx++;
            cutsceneStart = false;
            characterControllerBase.gossipSearch = true;
        } else {
            skipButton.SetActive(true);
            changePortriat(cutsceneManager.cutscene6.portraitBank[pageIdx]);
            dialogueTextBox.text = cutsceneManager.cutscene6.diagBank[pageIdx++];
        }
    }

    private void LoadCutscene7() {
        Debug.Log("Load Cutscene 7");
        skipButton.SetActive(true);
        changePortriat(cutsceneManager.cutscene7.portraitBank[pageIdx]);
        dialogueTextBox.text = cutsceneManager.cutscene7.diagBank[0];
    }

    private void Cutscene7() {
        if(pageIdx == cutsceneManager.cutscene7.diagBank.Count) {
            Debug.Log("End of Cutscene");
            characterControllerBase.endofDialogue = true;
            continueTextBox.SetActive(true);
            skipButton.SetActive(false);
            pageIdx = 0;
            chapterIdx++;
            cutsceneStart = false;
            characterControllerBase.gossipSearch = true;
        } else if(pageIdx == diagOptIdx1) { //hard coding when the dialogue option is supposed to start
            dialogueOptions.SetActive(true);
            diagOptions.SetOptions(dialogueDictionaries.diagOptions.dialogueOptionsBank1[0],
                dialogueDictionaries.diagOptions.dialogueOptionsBank1[1], dialogueDictionaries.diagOptions.dialogueOptionsBank1[2]);
            skipButton.SetActive(false);
        } else {
            skipButton.SetActive(true);
            changePortriat(cutsceneManager.cutscene7.portraitBank[pageIdx]);
            dialogueTextBox.text = cutsceneManager.cutscene7.diagBank[pageIdx++];
        }
    }

    private void LoadCutscene8() {
        Debug.Log("Load Cutscene 8");
        skipButton.SetActive(true);
        changePortriat(cutsceneManager.cutscene8.portraitBank[pageIdx]);
        dialogueTextBox.text = cutsceneManager.cutscene8.diagBank[0];
    }

    private void Cutscene8() {
        if(pageIdx == cutsceneManager.cutscene8.diagBank.Count) {
            Debug.Log("End of Cutscene");
            characterControllerBase.endofDialogue = true;
            continueTextBox.SetActive(true);
            skipButton.SetActive(false);
            pageIdx = 0;
            chapterIdx++;
            cutsceneStart = false;
            characterControllerBase.gossipSearch = true;
        } else if(pageIdx == diagOptIdx1) { //hard coding when the dialogue option is supposed to start
            dialogueOptions.SetActive(true);
            diagOptions.SetOptions(dialogueDictionaries.diagOptions.dialogueOptionsBank1[0],
                dialogueDictionaries.diagOptions.dialogueOptionsBank1[1], dialogueDictionaries.diagOptions.dialogueOptionsBank1[2]);
            skipButton.SetActive(false);
        } else {
            skipButton.SetActive(true);
            changePortriat(cutsceneManager.cutscene8.portraitBank[pageIdx]);
            dialogueTextBox.text = cutsceneManager.cutscene8.diagBank[pageIdx++];
        }
    }
}

