using UnityEngine;
using System.Collections.Generic;
using TMPro;
using System.Runtime.InteropServices;
using UnityEditor.Compilation;


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
        public List<string> options;
        public List<DialogueNode> responses1;
        public List<DialogueNode> responses2;
        public List<DialogueNode> responses3;
    }

    [System.Serializable]
    public class ConnectNode
    {
        public bool check;
        public int responseIdx = 0;
        public List<DialogueNode> responses1;
        public List<DialogueNode> responses2;
    }

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
        public DialogueNode dialogueNode;
        public BranchNode branchNode;
        public ConnectNode connectNode;
    }

    [Header("DialogueNode Variables")]
    public TMP_Text nameBoxTxt;
    public TMP_Text bodyTxt;

    [Header("BranchNode Object Variables")]
    public GameObject options1GameObj;
    public GameObject options2GameObj;
    public GameObject options3GameObj;
    [Header("BranchNode Text Variables")]
    public TMP_Text option1;
    public TMP_Text option2;
    public TMP_Text option3;

    private int currIdx = 0;
    private int reponseIdx = 0;
    private int playerChoice = 0;
    private bool inBranch = false;
    [SerializeField] public List<CompositeNode> nodeList = new List<CompositeNode>();

    void Awake() {
        options1GameObj.SetActive(false);
        options2GameObj.SetActive(false);
        options3GameObj.SetActive(false);
        
        // make sure nodelist isnt empty
        if (nodeList != null) {
            // show first node
            CompositeNode node = nodeList[0];
            

            if(node.type == CompositeNode.NodeType.Dialogue) {
                DialogueNode dNode = node.dialogueNode;
                nameBoxTxt.text = dNode.speaker;
                bodyTxt.text = dNode.text;
            }
        } else { Debug.LogError("Node List is empty"); }
    }

    public void ReadList() {
        if(currIdx >= 0 && currIdx < nodeList.Count) {
            CompositeNode node = nodeList[currIdx];

            if(inBranch && reponseIdx >= 0) {
                BranchNode bNode = node.branchNode;

                switch(playerChoice) 
                {
                    case 1:
                        if(bNode.responses1 != null) {
                            if(reponseIdx < bNode.responses1.Count) {
                                DialogueNode dNode = bNode.responses1[reponseIdx];

                                nameBoxTxt.text = dNode.speaker;
                                bodyTxt.text = dNode.text;
                                reponseIdx++;
                            }

                            if(reponseIdx < bNode.responses1.Count) { inBranch = false; }
                        } else { Debug.LogError("Branch responses are empty"); }
                    break;
                    case 2:
                        if(bNode.responses2 != null) {
                            if(reponseIdx < bNode.responses2.Count) {
                                DialogueNode dNode = bNode.responses2[reponseIdx];

                                nameBoxTxt.text = dNode.speaker;
                                bodyTxt.text = dNode.text;
                                reponseIdx++;
                            }

                            if(reponseIdx < bNode.responses1.Count) { inBranch = false; }
                        } else { Debug.LogError("Branch responses are empty"); }
                    break;
                    case 3:
                        if(bNode.responses3 != null) {
                            if(reponseIdx < bNode.responses3.Count) {
                                DialogueNode dNode = bNode.responses3[reponseIdx];

                                nameBoxTxt.text = dNode.speaker;
                                bodyTxt.text = dNode.text;
                                reponseIdx++;
                            }
                            
                            if(reponseIdx < bNode.responses1.Count) { inBranch = false; }
                        } else { Debug.LogError("Branch responses are empty"); }
                    break;
                }
            }

            if(node.type == CompositeNode.NodeType.Dialogue) {
                DialogueNode dNode = node.dialogueNode;

                if(dNode != null) {
                    nameBoxTxt.text = dNode.speaker;
                    bodyTxt.text = dNode.text;
                    currIdx++;
                } else { Debug.LogError("Dialogue Node is empty"); }
            }

            if(node.type == CompositeNode.NodeType.Branch && inBranch == false) {
                // check how many options are there
                BranchNode bNode = node.branchNode;

                if(bNode != null) {
                    if(bNode.options.Count == 2) {
                        //activate UI
                        options1GameObj.SetActive(true);
                        options2GameObj.SetActive(true);

                        //Set Option texts
                        option1.text = bNode.options[0];
                        option2.text = bNode.options[1];
                    } else if(bNode.options.Count == 3) {
                        // activate UI
                        options1GameObj.SetActive(true);
                        options2GameObj.SetActive(true);
                        options3GameObj.SetActive(true);

                        //Set Option texts
                        option1.text = bNode.options[0];
                        option2.text = bNode.options[1];
                        option3.text = bNode.options[2];
                    } else {
                        Debug.Log("Incorrect number of options detected");
                    }
                }
            }

            if(node.type == CompositeNode.NodeType.ConnectNode) {
                ConnectNode cNode = node.connectNode;

                if(cNode.check) {
                    if(inBranch) {
                        if(cNode.responses1 != null) {
                            if(cNode.responseIdx < cNode.responses1.Count) {
                                DialogueNode dNode = cNode.responses1[cNode.responseIdx];

                                nameBoxTxt.text = dNode.speaker;
                                bodyTxt.text = dNode.text;
                                cNode.responseIdx++;
                            }

                            if(reponseIdx < cNode.responses1.Count) { inBranch = false; }
                        }
                    
                    } else { Debug.LogError("Connect responses are empty"); }
                } else {
                    if(inBranch) {
                        if(cNode.responses2 != null) {
                            if(cNode.responseIdx < cNode.responses2.Count) {
                                DialogueNode dNode = cNode.responses2[cNode.responseIdx];

                                nameBoxTxt.text = dNode.speaker;
                                bodyTxt.text = dNode.text;
                                cNode.responseIdx++;
                            }

                            if(reponseIdx < cNode.responses2.Count) { inBranch = false; }
                        }
                    
                    } else { Debug.LogError("Connect responses are empty"); }
                }
            }
        } else { Debug.LogError("Node List is complete"); } // do next thing
    }

    public void Option1() {
        playerChoice = 1;
        // deactivate UI
        options1GameObj.SetActive(false);
        options2GameObj.SetActive(false);
        options3GameObj.SetActive(false);
        
        // Show players reponse
        nameBoxTxt.text = "Bailey";
        bodyTxt.text = option1.text;

        inBranch = true;
    }

    public void Option2() {
        playerChoice = 2;
        // deactivate UI
        options1GameObj.SetActive(false);
        options2GameObj.SetActive(false);
        options3GameObj.SetActive(false);
        
        // Show players reponse
        nameBoxTxt.text = "Bailey";
        bodyTxt.text = option2.text;

        inBranch = true;
    }
    
    public void Option3() {
        playerChoice = 2;
        // deactivate UI
        options1GameObj.SetActive(false);
        options2GameObj.SetActive(false);
        options3GameObj.SetActive(false);
        
        // Show players reponse
        nameBoxTxt.text = "Bailey";
        bodyTxt.text = option3.text;

        inBranch = true;
    }
}