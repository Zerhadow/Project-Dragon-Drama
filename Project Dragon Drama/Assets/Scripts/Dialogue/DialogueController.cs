using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    
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

    private int currIdxDNList = 0; //idx for composite dnode list
    private int currIdxBNList = 0; //idx for composite dnode list
    private int playerChoice = 0;
    private bool inBranch = false;

    [SerializeField] public CompositeNode compositeNode;

    private void Awake() {
        dialogueOptionsObj.SetActive(false);
    }

    public void SetCompositeNode(CompositeNode compositeNode) {
        if(compositeNode != null) {
            this.compositeNode = compositeNode;
        } else { Debug.LogError("Node empty"); }
    }

    public void ReadCompositeNode() {
        if(currIdxBNList == 0 && currIdxDNList == 0) { // original start
            if(!compositeNode.startWithBranch) { // start with DN1
                if(compositeNode.dNode[0] != null) {
                    DialogueNodeList DN = compositeNode.dNode[0];
                    nameBoxTxt.text = DN.nodeList[0].speaker;
                    bodyTxt.text = DN.nodeList[0].text;
                    DN.idx++;
                } else { Debug.LogError("1st DN of CN empty"); }
            } else { // start with BN1
                if(compositeNode.bNode != null) {
                    BranchNode branchNodeList = compositeNode.bNode[0];
                    ShowOptions(branchNodeList);
                    inBranch = true;
                }
            }
        }
    }

    private void UpdateScreen() {

    }

    private void ShowOptions(BranchNode branchNodeList) {
        if(branchNodeList.options != null) {
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
    }

    public void Skip() {

    }
    
    public void ReadList() {
        // if(inBranch) {
        //     ReadBranchDialogueList(); // indicates we are inside branch dialogue list
        // } else

        // if(currIdx >= 0 && currIdx < nodeList.Count) {
        //     CompositeNode node = nodeList[currIdx];

        //     if(node.dNodeList != null) { // means that its a dialogue node list
        //         DialogueNodeList dialogueNodeList = node.dNodeList;
        //         GetDialogueNode(dialogueNodeList);
        //     } else if(node.bNode != null) { // means that its a dialogue node list
        //         BranchNode branchNodeList = node.bNode;

        //         if(branchNodeList.options != null) {
        //             inBranch = true;

        //             if(branchNodeList.options.Count == 2) {
        //                 dialogueOptionsObj.SetActive(true);
        //                 options3GameObj.SetActive(false);

        //                 // Set Option Texts
        //                 option1.text = branchNodeList.options[0];
        //                 option2.text = branchNodeList.options[1];
        //             }

        //             if(branchNodeList.options.Count == 3) {
        //                 dialogueOptionsObj.SetActive(true);

        //                 //Set Option texts
        //                 option1.text = branchNodeList.options[0];
        //                 option2.text = branchNodeList.options[1];
        //                 option3.text = branchNodeList.options[2];
        //             }
        //         } else { Debug.LogError("Fill options list"); }
        //     } else { Debug.LogError("Dialogue Node List is empty"); }
        // } else { 
        //     Debug.Log("Node List is complete");
        //     // Change states so player can do next thing
        //     gameController._stateMachine.ChangeState(gameController._stateMachine.PlayState);
        // } 
    }

    public void ReadBranchDialogueList() {
        // CompositeNode node = nodeList[currIdx];
        // // BranchNode branchNodeList = node.bNode;
        // Debug.Log("player choice: " + playerChoice);

        // if(playerChoice == 1) {
        //     DialogueNodeList dialogueNodeList = branchNodeList.dlist1;
        //     Debug.Log("Idx: " + dialogueNodeList.idx);

        //     if(dialogueNodeList != null) {
        //         GetDialogueNode(dialogueNodeList);
        //     } else { Debug.LogError("Branch response empty"); }
        // }
    
        // if(playerChoice == 2) {
        //     DialogueNodeList dialogueNodeList = branchNodeList.dlist2;
        //     Debug.Log("Idx: " + dialogueNodeList.idx);

        //     if(dialogueNodeList != null) {
        //         GetDialogueNode(dialogueNodeList);
        //     } else { Debug.LogError("Branch response empty"); }
        // }

        // if(playerChoice == 3) {
        //     DialogueNodeList dialogueNodeList = branchNodeList.dlist3;
        //     Debug.Log("Idx: " + dialogueNodeList.idx);

        //     if(dialogueNodeList != null) {
        //         GetDialogueNode(dialogueNodeList);
        //     } else { Debug.LogError("Branch response empty"); }
        // }
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
            // currIdx++;
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
