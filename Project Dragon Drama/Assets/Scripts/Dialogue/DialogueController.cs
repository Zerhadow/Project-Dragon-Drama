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
    
    [Header("DialogueNode Variables")]
    public TMP_Text nameBoxTxt;
    public TMP_Text bodyTxt;

    [Header("BranchNode Object Variables")]
    public GameObject dialogueOptionsObj;
    [Header("BranchNode Text Variables")]
    public TMP_Text option1;
    public TMP_Text option2;
    public TMP_Text option3;

    private int currIdx = 0;
    private int playerChoice = 0;
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
            }
        } else { Debug.LogError("Node List is empty"); }
    }

    public void ReadList() {
        if(currIdx >= 0 && currIdx < nodeList.Count) {
            CompositeNode node = nodeList[currIdx];

            if(node.dNodeList != null) { // means that its a dialogue node list
                DialogueNodeList dialogueNodeList = node.dNodeList;

                if(dialogueNodeList.idx > dialogueNodeList.nodeList.Count) {
                    nameBoxTxt.text = dialogueNodeList.nodeList[dialogueNodeList.idx].speaker;
                    bodyTxt.text = dialogueNodeList.nodeList[dialogueNodeList.idx].text;
                    dialogueNodeList.idx += 1;
                } else { // move onto next composite node
                    Debug.Log("DList done");
                }
            } else { Debug.LogError("Dialogue Node List is empty"); }
        } else { Debug.Log("Node List is complete"); } // do next thing
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
        playerChoice = 2;
        // deactivate UI
        dialogueOptionsObj.SetActive(false);
        
        // Show players reponse
        nameBoxTxt.text = "Bailey";
        bodyTxt.text = option3.text;
    }
}
