using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    [Header("Game System Dependencies")]
    private GameController gameController;
    public PortraitController portraitController;

    [Header("Node Info")]
    private NodeList nodeList;
    private int currentNodeIndex = 0;
    private Node currentNode;
    private Node lastNode;
    [Header("Main Story Node Lists")]
    [SerializeField] public List<NodeList> mainNodeLists;
    [SerializeField] public List<NodeList> eveningCharBooks;
    private int mainPlotLineIdx;
    private bool mainPlot = false;

    private void Awake() {
        gameController = GetComponentInParent<GameController>();
        gameController.UI.dialogueOptionsObj.SetActive(false);
    }

    public void SetCurrentNodeList(NodeList list) {
        nodeList = list;
    }

        // Call this method to start the dialogue
    public void StartDialogue() {
        if(nodeList == null) { // if empty in case of mainNode plot line
            nodeList = mainNodeLists[mainPlotLineIdx];
            mainPlot = true;
        }

        if (nodeList.nodes.Count > 0) {
            currentNodeIndex = 0;
            ActivateCurrentNode();
        } else {
            Debug.LogWarning("Node list is empty!");
        }
    }

    // Call this method to progress to the next node
    public void NextNode() {
        Debug.Log("Linked? " + nodeList.linked);

        if (currentNodeIndex < nodeList.nodes.Count - 1) { // if the node isnt the last one
            currentNodeIndex++;
            ActivateCurrentNode();
        } else if(nodeList.linked) {
            nodeList = nodeList.linkedNL;
            currentNodeIndex = 0;
            ActivateCurrentNode();
        } else {
            EndTalk();
        }
    }

    private void EndTalk() {
        Debug.Log("End of dialogue.");

        if(mainPlot) {
            mainPlotLineIdx++;
            mainPlot = false;
        }

        // Advance time
        if(nodeList.advanceTime) {
            gameController.gameTimeController.AdvanceTime();
        }

        nodeList = null; // reset nodelist

        // find previous state and go back to it
        gameController.ChangeStates("Explore");
    }

    // Goes to end of node list
    public void Skip() {
        Debug.Log("Skipping dialogue");

        lastNode = nodeList.nodes.Last();

        // Debug.Log("Type: " + lastNode.nodeType);

        currentNode = lastNode;
        currentNodeIndex = nodeList.nodes.Count - 1;
        ActivateCurrentNode();
    }

    private void ActivateCurrentNode() {
        currentNode = nodeList.nodes[currentNodeIndex];

        if(currentNode.nodeType == NodeType.Dialogue) {
            DialogueNode dn = currentNode as DialogueNode;
            UpdateUIDN(dn);
        } else if (currentNode.nodeType == NodeType.Branch) {
            BranchNode bn = currentNode as BranchNode;
            UpdateUIBN(bn);
        } else if (currentNode.nodeType == NodeType.AutoBranch) {
            AutoBranchNode abn = currentNode as AutoBranchNode;
            SetCurrentNodeList(GetAutoNodeList(abn));
            StartDialogue();
        } else if (currentNode.nodeType == NodeType.Stat) {
            StatNode bn = currentNode as StatNode;
            Debug.Log("Modifying stats");
        } else if (currentNode.nodeType == NodeType.SYSCALL) {
            // make node
            SystemCallNode syscall = currentNode as SystemCallNode;
            Debug.Log("SYS has been called. Reading Action");
            ReadSysCallAction(syscall.action);
        }

        // else if (currentNode.nodeType == NodeType.Quest) {

        // } 
        else {
            Debug.LogError("Unknown node type used");
        }
    }

    private void UpdateUIDN(DialogueNode dn)
    {
        gameController.UI.nameBoxTxt.text = dn.speakerName;
        gameController.UI.bodyTxt.text = dn.dialogueText.Trim();
        portraitController.SetPortrait(dn.speakerName, 0);
    }

    private void UpdateUIBN(BranchNode bn) {
        // update the box for prev
        lastNode = nodeList.nodes[currentNodeIndex -1];
        DialogueNode dn = lastNode as DialogueNode;
        gameController.UI.nameBoxTxt.text = dn.speakerName;
        gameController.UI.bodyTxt.text = dn.dialogueText.Trim();
        portraitController.SetPortrait(dn.speakerName, 0);
        
        gameController.UI.dialogueOptionsObj.SetActive(true);
        gameController.UI.btnsObj.SetActive(false);
        gameController.UI.option1.text = bn.opt1txt;
        gameController.UI.option2.text = bn.opt2txt;

        if(bn.option3 != null) {
            gameController.UI.dialogueOptions3Obj.SetActive(true);
            gameController.UI.option3.text = bn.opt3txt;
        } else {
            gameController.UI.dialogueOptions3Obj.SetActive(false);
        }
    }

    public void Option1() {
        BranchNode bn = currentNode as BranchNode;
        SetCurrentNodeList(bn.option1);
        gameController.UI.dialogueOptionsObj.SetActive(false);
        StartDialogue();
        gameController.UI.btnsObj.SetActive(true);
    }

    public void Option2() {
        BranchNode bn = currentNode as BranchNode;
        SetCurrentNodeList(bn.option2);
        gameController.UI.dialogueOptionsObj.SetActive(false);
        StartDialogue();
        gameController.UI.btnsObj.SetActive(true);
    }

    public void Option3() {
        BranchNode bn = currentNode as BranchNode;
        SetCurrentNodeList(bn.option3);
        gameController.UI.dialogueOptionsObj.SetActive(false);
        StartDialogue();
        gameController.UI.btnsObj.SetActive(true);
    }

    private NodeList GetAutoNodeList(AutoBranchNode cn) {
        // get bool from player controller\
        FlagController fc = gameController.playerController.flagController;
        bool b = fc.GetFlag(cn.flagName);

        // update nodelist based off bool
        if(b) {
            return cn.nl1;
        } else {
            return cn.nl2;
        }
    }

    private void ReadSysCallAction(string str) {
        switch (str) {
        case "Next Scene":
            Debug.Log("Going to next scene");
            gameController.NextScene();
            break;
        case "Fade In":
            // call game or ui controller to fade in scene
            break;
        case "Fade Out":
            // call game or ui controller to fade out scene
            break;
        default:
            break;
        }
    }
}