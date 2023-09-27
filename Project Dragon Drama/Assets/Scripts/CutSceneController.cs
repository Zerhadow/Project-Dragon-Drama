using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CutSceneController : MonoBehaviour
{
    DialogueDictionaries dialogueDictionaries = new DialogueDictionaries();
    CutsceneManager cutsceneManager = new CutsceneManager();
    public TMP_Text dialogueTextBox;
    List<Entry> entryList = new List<Entry>();
    Entry entry;
    int chapterIdx, pageIdx;
    public GameObject playerPFP, mg1PFP, mg2PFP, mg3PFP, friendPFP;
    public bool cutsceneStart = false;
    public CharacterControllerBase characterControllerBase;
    public GameObject continueTextBox;
    
    public GameObject dialogueOptions;
    public DiagOptions diagOptions;
    bool diagOptReady = false;
    public GameObject skipButton;

    
    void Awake() {
        dialogueDictionaries.player.fillBank();
        dialogueDictionaries.meangirl1.fillBank();
        dialogueDictionaries.meangirl2.fillBank();
        dialogueDictionaries.meangirl3.fillBank();
        dialogueDictionaries.friend.fillBank();
        dialogueDictionaries.diagOptions.fillBank1();
        cutsceneManager.cutscene1.fillBank(dialogueDictionaries);
        chapterIdx = 0;
        pageIdx = 0;
        continueTextBox.SetActive(false);
        dialogueOptions.SetActive(false);
        diagOptions = this.GetComponent<DiagOptions>();
        skipButton.SetActive(false);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Entry entry = new Entry();

        # region Start of Chapter 1
        entry.createEntry(0, 1, dialogueDictionaries.player.playerDiagBank[0], false, true);
        entryList.Add(entry);

        Entry entry2 = new Entry();
        entry2.createEntry(1, 0, dialogueDictionaries.meangirl1.meangirl1DiagBank[0], true, false);
        entryList.Add(entry2);
        // dialogueTextBox.text = entryList[pageIdx].text;

        Entry entry3 = new Entry();
        entry3.createEntry(1, 0, dialogueDictionaries.meangirl1.meangirl1DiagBank[1], true, false);
        entryList.Add(entry3);
        
        # endregion
    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.E) && cutsceneStart) {
            if(diagOptReady) {
                diagOptReady = false;
                changePotriat();
                dialogueTextBox.text = entryList[pageIdx++].text;
            }
            
            // if(pageIdx == entryList.Count) {
            //     Debug.Log("End of Cutscene");
            //     characterControllerBase.setEndofDialogue(true);
            //     pageIdx = 0;
            //     continueTextBox.SetActive(true);
            //     skipButton.SetActive(false);
            // }

            // else if(pageIdx == 2) {
            //     dialogueOptions.SetActive(true);
            //     diagOptions.SetOptions(dialogueDictionaries.diagOptions.dialogueOptionsBank1[0],
            //         dialogueDictionaries.diagOptions.dialogueOptionsBank1[1], dialogueDictionaries.diagOptions.dialogueOptionsBank1[2]);
            //     skipButton.SetActive(false);
            // }
            if(cutsceneStart) {
                if(chapterIdx == 0) {
                    if(pageIdx == cutsceneManager.cutscene1.cutscene1DiagBank.Count) {
                        Debug.Log("End of Cutscene");
                        characterControllerBase.setEndofDialogue(true);
                        pageIdx = 0;
                        continueTextBox.SetActive(true);
                        skipButton.SetActive(false);
                        chapterIdx++;
                        characterControllerBase.gossipSearch = true;
                    } else {
                        skipButton.SetActive(true);
                        changePotriat2(cutsceneManager.cutscene1.portraitBank[pageIdx]);
                        dialogueTextBox.text = cutsceneManager.cutscene1.cutscene1DiagBank[pageIdx++];
                    }
                } else if(chapterIdx == 1) {

                }
                
                // cutsceneStart = false;
            } 
        }

        if(diagOptions.ifPressed) {
            Debug.Log("Option Chosen: " + diagOptions.optionChosen);
            diagOptions.ifPressed = false;
            dialogueOptions.SetActive(false);
            diagOptReady = true;
            changePotriatToPlayer();
            dialogueTextBox.text = diagOptions.optionChosen;
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

    void changePotriatToPlayer() {
        playerPFP.SetActive(true);
        mg1PFP.SetActive(false);
    }

    void changePotriat() {
        //set pfp
        if(entryList[pageIdx].char1 == 0) { //player
            playerPFP.SetActive(true);
            mg1PFP.SetActive(false);
        } else if (entryList[pageIdx].char1 == 1) { //mg1
            playerPFP.SetActive(false);
            mg1PFP.SetActive(true);
        } else if(entryList[pageIdx].char1 == 2) { //mg2
            playerPFP.SetActive(false);
            mg1PFP.SetActive(false);
        } else if(entryList[pageIdx].char1 == 3) { //mg3
            playerPFP.SetActive(false);
            mg1PFP.SetActive(false);
        }
    }

    void changePotriat2(int idx) {
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

    void npcPotriat() {
        playerPFP.SetActive(false);
    }

    public void NPCtalk(NPCControllerBase npc) {
        npcPotriat();
        Debug.Log("NPC diag:" + npc.gossipText);
        dialogueTextBox.text = npc.gossipText;
        characterControllerBase.setEndofDialogue(true);
    }

    public void SkipCutscene() {
        Debug.Log("Skip Cutscene");
        cutsceneStart = false;
        dialogueTextBox.text = "";
        continueTextBox.SetActive(false);
        characterControllerBase.dialogueTextBox.SetActive(false);
        characterControllerBase.setEndofDialogue(true);
        pageIdx = entryList.Count;
        chapterIdx++;
    }
}

