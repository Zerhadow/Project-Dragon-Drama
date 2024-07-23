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
        NodeContent content = currentNode.GetContent();

        if(currentNode.nodeType == NodeType.Dialogue) {
            UpdateUIDN(content);
        } else if (currentNode.nodeType == NodeType.Branch) {
            UpdateUIBN(content);
        } 
        // else if (currentNode.nodeType == NodeType.Quest) {

        // } 
        else {
            Debug.LogError("Unknown node type used");
        }
    }

    private void UpdateUIDN(NodeContent content)
    {
        gameController.UI.nameBoxTxt.text = content.speakerName;
        gameController.UI.bodyTxt.text = content.bodyText;
        portraitController.SetPortrait(content.speakerName, 0);
    }

    private void UpdateUIBN(NodeContent content) {
        gameController.UI.dialogueOptionsObj.SetActive(true);
        gameController.UI.btnsObj.SetActive(false);
        gameController.UI.option1.text = content.opt1;
        gameController.UI.option2.text = content.opt2;
    }

    public void Option1() {
        NodeContent content = currentNode.GetContent();
        SetCurrentNodeList(content.option1NodeList);
        gameController.UI.dialogueOptionsObj.SetActive(false);
        StartDialogue();
        gameController.UI.btnsObj.SetActive(true);
    }

    public void Option2() {
        NodeContent content = currentNode.GetContent();
        SetCurrentNodeList(content.option2NodeList);
        gameController.UI.dialogueOptionsObj.SetActive(false);
        StartDialogue();
        gameController.UI.btnsObj.SetActive(true);
    }

    public void Option3() {
        NodeContent content = currentNode.GetContent();
        SetCurrentNodeList(content.option3NodeList);
        gameController.UI.dialogueOptionsObj.SetActive(false);
        StartDialogue();
        gameController.UI.btnsObj.SetActive(true);
    }
}