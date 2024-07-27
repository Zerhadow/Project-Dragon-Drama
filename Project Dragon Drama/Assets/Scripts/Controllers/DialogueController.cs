using System.Collections;
using System.Collections.Generic;
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
    [Header("Main Story Node Lists")]
    [SerializeField] public List<NodeList> mainNodeLists;

    private void Awake() {
        gameController = GetComponentInParent<GameController>();
        gameController.UI.dialogueOptionsObj.SetActive(false);
    }

    public void SetCurrentNodeList(NodeList list) {
        nodeList = list;
    }

        // Call this method to start the dialogue
    public void StartDialogue() {
        if (nodeList.nodes.Count > 0) {
            currentNodeIndex = 0;
            ActivateCurrentNode();
        } else {
            Debug.LogWarning("Node list is empty!");
        }
    }

    // Call this method to progress to the next node
    public void NextNode() {
        if (currentNodeIndex < nodeList.nodes.Count - 1) {
            currentNodeIndex++;
            ActivateCurrentNode();
        } else {
            Debug.Log("End of dialogue.");
            // find previous state and go back to it
            gameController.ChangeToPreviousState();
        }
    }

    // Goes to end of node list
    public void Skip() {
        Debug.Log("Skipping dialogue");

        if (currentNodeIndex != nodeList.nodes.Count - 1 &
            currentNodeIndex > nodeList.nodes.Count - 1) {
            currentNodeIndex = nodeList.nodes.Count - 1; // make currNidx last idx
            ActivateCurrentNode();
        }
    }

    private void ActivateCurrentNode() {
        currentNode = nodeList.nodes[currentNodeIndex];
        // NodeContent content = currentNode.GetContent();

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
        gameController.UI.bodyTxt.text = dn.dialogueText;
        portraitController.SetPortrait(dn.speakerName, 0);
    }

    private void UpdateUIBN(BranchNode bn) {
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
        // get bool from player controller
        bool b = gameController.playerController.flagController.GetFlag(cn.flagName);

        // update nodelist based off bool
        if(b) {
            return cn.nl1;
        } else {
            return cn.nl2;
        }
    }
}