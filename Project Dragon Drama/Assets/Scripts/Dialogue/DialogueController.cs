using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    [System.Serializable]
    public class CompositeNode
    {
        public enum NodeType
        {
            Dialogue,
            Branch,
            ConnectNode
        }

        public NodeType type;
        public DialogueNodeList dNodeList;
        public BranchNodeList bNodelist;
        // public ConnectNode connectNode;
    }
    
    [Header("Game System Dependencies")]
    public GameController gameController;
    [Header("DialogueNode Variables")]
    public TMP_Text nameBoxTxt;
    public TMP_Text bodyTxt;

    [Header("BranchNode Object Variables")]
    public GameObject dialogueOptionsObj;
    public GameObject options3GameObj;

    [Header("BranchNode Text Variables")]
    public TMP_Text option1;
    public TMP_Text option2;
    public TMP_Text option3;
    [Header("Other Stuff")]

    private int currIdx = 0; //idx for composite list
    private int playerChoice = 0;
    private bool inBranch = false;

    [SerializeField] public List<CompositeNode> nodeList = new List<CompositeNode>();

    private void Awake() {
        dialogueOptionsObj.SetActive(false);

        // make sure nodelist isnt empty
        if (nodeList != null) {
            // show first node
            CompositeNode node = nodeList[currIdx];
            
            if(node.dNodeList != null) { // means that its a dialogue node list
                nameBoxTxt.text = node.dNodeList.nodeList[0].speaker;
                bodyTxt.text = node.dNodeList.nodeList[0].text;
                node.dNodeList.idx = 0;
            }
        } else { Debug.LogError("Node List is empty"); }
    }

    public void ReadList() {
        if(inBranch) {
            ReadBranchDialogueList(); // indicates we are inside branch dialogue list
        } else

        if(currIdx >= 0 && currIdx < nodeList.Count) {
            CompositeNode node = nodeList[currIdx];

            if(node.dNodeList != null) { // means that its a dialogue node list
                DialogueNodeList dialogueNodeList = node.dNodeList;
                GetDialogueNode(dialogueNodeList);
            } else if(node.bNodelist != null) { // means that its a dialogue node list
                BranchNodeList branchNodeList = node.bNodelist;

                if(branchNodeList.options != null) {
                    inBranch = true;

                    if(branchNodeList.options.Count == 2) {
                        dialogueOptionsObj.SetActive(true);
                        options3GameObj.SetActive(false);

                        // Set Option Texts
                        option1.text = branchNodeList.options[0];
                        option2.text = branchNodeList.options[1];
                    }

                    if(branchNodeList.options.Count == 3) {
                        dialogueOptionsObj.SetActive(true);

                        //Set Option texts
                        option1.text = branchNodeList.options[0];
                        option2.text = branchNodeList.options[1];
                        option3.text = branchNodeList.options[2];
                    }
                } else { Debug.LogError("Fill options list"); }
            } else { Debug.LogError("Dialogue Node List is empty"); }
        } else { 
            Debug.Log("Node List is complete");
            // Change states so player can do next thing
            gameController._stateMachine.ChangeState(gameController._stateMachine.SetupState);
        } 
    }

    public void ReadBranchDialogueList() {
        CompositeNode node = nodeList[currIdx];
        BranchNodeList branchNodeList = node.bNodelist;
        Debug.Log("player choice: " + playerChoice);

        if(playerChoice == 1) {
            DialogueNodeList dialogueNodeList = branchNodeList.dlist1;
            Debug.Log("Idx: " + dialogueNodeList.idx);

            if(dialogueNodeList != null) {
                GetDialogueNode(dialogueNodeList);
            } else { Debug.LogError("Branch response empty"); }
        }
    
        if(playerChoice == 2) {
            DialogueNodeList dialogueNodeList = branchNodeList.dlist2;
            Debug.Log("Idx: " + dialogueNodeList.idx);

            if(dialogueNodeList != null) {
                GetDialogueNode(dialogueNodeList);
            } else { Debug.LogError("Branch response empty"); }
        }

        if(playerChoice == 3) {
            DialogueNodeList dialogueNodeList = branchNodeList.dlist3;
            Debug.Log("Idx: " + dialogueNodeList.idx);

            if(dialogueNodeList != null) {
                GetDialogueNode(dialogueNodeList);
            } else { Debug.LogError("Branch response empty"); }
        }
    }

    public void GetDialogueNode(DialogueNodeList dialogueNodeList) {
        if(dialogueNodeList.idx < dialogueNodeList.nodeList.Count) {
            nameBoxTxt.text = dialogueNodeList.nodeList[dialogueNodeList.idx].speaker;
            bodyTxt.text = dialogueNodeList.nodeList[dialogueNodeList.idx].text;
            dialogueNodeList.idx += 1;
        } else { // move onto next composite node
            Debug.Log("DList done");
            dialogueNodeList.idx = 0;
            if(inBranch) inBranch = false;
            currIdx++;
        }
    }
    
    public void Option1() {
        playerChoice = 1;
        // deactivate UI
        dialogueOptionsObj.SetActive(false);
        
        // Show players reponse
        nameBoxTxt.text = "Bailey";
        bodyTxt.text = option1.text;
    }

    public void Option2() {
        playerChoice = 2;
        // deactivate UI
        dialogueOptionsObj.SetActive(false);
        
        // Show players reponse
        nameBoxTxt.text = "Bailey";
        bodyTxt.text = option2.text;
    }
    
    public void Option3() {
        playerChoice = 3;
        // deactivate UI
        dialogueOptionsObj.SetActive(false);
        
        // Show players reponse
        nameBoxTxt.text = "Bailey";
        bodyTxt.text = option3.text;
    }
}
