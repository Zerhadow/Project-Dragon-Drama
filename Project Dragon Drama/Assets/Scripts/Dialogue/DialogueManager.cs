using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static ImportFile;

public class DialogueManager : MonoBehaviour
{    
    public ImportFile importFile;
    public TMP_Text nameBoxTxt;
    public TMP_Text bodyTxt;
    private int currIdx = 0;

    // Start is called before the first frame update
    void Start()
    {
        List<DialogueEntry> dialogueNodes = importFile.dialogueNodes;

        DialogueEntry node = dialogueNodes[currIdx];
        nameBoxTxt.text = node.speaker;
        bodyTxt.text = node.text;
        currIdx++;
    }

    public void ReadNextNode() {
        List<DialogueEntry> dialogueNodes = importFile.dialogueNodes;

        if(dialogueNodes[currIdx] != null && currIdx >= 0 && currIdx < dialogueNodes.Count) {
            DialogueEntry node = dialogueNodes[currIdx];
            nameBoxTxt.text = node.speaker;
            bodyTxt.text = node.text;

            currIdx++;
        }
    }
}
