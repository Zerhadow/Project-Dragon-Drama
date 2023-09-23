using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CutSceneController : MonoBehaviour
{
    DialogueDictionaries dialogueDictionaries = new DialogueDictionaries();
    public TMP_Text dialogueTextBox;
    List<Entry> entryList = new List<Entry>();
    Entry entry;
    int chapterIdx, pageIdx;
    public GameObject playerPFP, mg1PFP;
    public bool cutsceneStart = false;
    public CharacterControllerBase characterControllerBase;

    
    void Awake() {
        dialogueDictionaries.player.fillBank();
        dialogueDictionaries.meangirl1.fillBank();
        dialogueDictionaries.meangirl2.fillBank();
        dialogueDictionaries.meangirl3.fillBank();
        chapterIdx = 0;
        pageIdx = 0;
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
        dialogueTextBox.text = entryList[pageIdx].text;
        # endregion
    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.E) && cutsceneStart) {
            if(pageIdx == entryList.Count) {
                Debug.Log("End of Cutscene");
                characterControllerBase.setEndofDialogue(true);
                pageIdx = 0;
            } else {
                changePotriat();
                dialogueTextBox.text = entryList[pageIdx++].text;

            }
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

    void changePotriat() {
        //set pfp
        if(entryList[pageIdx].char1 == 0) {
            playerPFP.SetActive(true);
            mg1PFP.SetActive(false);
        } else if (entryList[pageIdx].char1 == 1) {
            playerPFP.SetActive(false);
            mg1PFP.SetActive(true);
        } else if(entryList[pageIdx].char1 == 2) {
            playerPFP.SetActive(false);
            mg1PFP.SetActive(false);
        } else if(entryList[pageIdx].char1 == 3) {
            playerPFP.SetActive(false);
            mg1PFP.SetActive(false);
        }
    }    
}

