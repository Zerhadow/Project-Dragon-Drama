using UnityEngine;
using System.Collections.Generic;
using TMPro;


public class DialogueManagerManual : MonoBehaviour
{
    [System.Serializable]
    public class DialogueNode
    {
        public string speaker;
        public string text;
        // public string facialExpression;
    }

    [System.Serializable]
    public class BranchNode
    {
        public List<DialogueNode> responses;
    }

    [System.Serializable]
    public class CompositeNode
    {
        public enum NodeType
        {
            Dialogue,
            Branch
        }

        public NodeType type;
        public DialogueNode dialogueNode;
        public BranchNode branchNode;
    }

    public TMP_Text nameBoxTxt;
    public TMP_Text bodyTxt;
    private int currIdx = 0;

    [SerializeField] public List<CompositeNode> nodeList = new List<CompositeNode>();

    void Awake() {
        // make sure nodelist isnt empty
        if (nodeList != null) {
            // show first node
            CompositeNode node = nodeList[0];

            if(node.type == CompositeNode.NodeType.Dialogue) {
                DialogueNode dNode = node.dialogueNode;
                nameBoxTxt.text = dNode.speaker;
                bodyTxt.text = dNode.text;
                currIdx++;
            }
        } else { Debug.LogError("Node List is empty"); }
    }
    public void ReadList() {
        if(currIdx >= 0 && currIdx < nodeList.Count) {
            CompositeNode node = nodeList[currIdx];

            if(node.type == CompositeNode.NodeType.Dialogue) {
                DialogueNode dNode = node.dialogueNode;

                if(dNode != null) {
                    nameBoxTxt.text = dNode.speaker;
                    bodyTxt.text = dNode.text;
                    currIdx++;
                } else { Debug.LogError("Dialogue Node is empty"); }
            }

            if(node.type == CompositeNode.NodeType.Branch) {
                
            }
        } else { Debug.LogError("Node List is complete"); } // do next thing
    }
}