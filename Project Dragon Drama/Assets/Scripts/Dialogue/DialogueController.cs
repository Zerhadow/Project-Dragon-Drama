using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    
    [Header("Game System Dependencies")]
    private GameController gameController;
    public PortraitController portraitController;
    public StatController statController;
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
    private int currIdxBNList = 0; //idx for composite bnode list
    private int currIdxDN = 0; //idx for DN node list
    private int playerChoice = 0;
    private bool inBranch = false, startDn = false, startBn = false;

    private CompositeNode compositeNode;
    private int cNodeListIdx = 0;
    [SerializeField] public List<CompositeNode> cNodeList;
    private DialogueNodeList currDN; // current dialogue node sys is going through
    private BranchNode currBN; // current branch node sys is going through

    private void Awake() {
        dialogueOptionsObj.SetActive(false);
        gameController = GetComponentInParent<GameController>();
        portraitController = GetComponent<PortraitController>();
        compositeNode = cNodeList[0];
    }

    public void SetCompositeNode() {
        compositeNode = cNodeList[cNodeListIdx];
        // Debug.Log("CN: " + compositeNode.name + " set");
    }

    public void ReadCompositeNode() {
        if(inBranch) {
            if(currIdxDN >= currDN.nodeList.Count - 1) { // finished with branch DN
                inBranch = false;
                startDn = true;
                currDN = compositeNode.dNode[currIdxDNList];
                currIdxDN = 0;
            } else {
                // check if curr dn has stat mod
                if(currDN.nodeList[currIdxDN].speaker.Trim().StartsWith("+") ) {
                    statController.ApplyModifier(currDN.nodeList[currIdxDN].speaker.Trim());
                    currIdxDN++;
                }
                UpdateScreen();
            }
        }

        if(currIdxDNList >= compositeNode.dNode.Count - 1 
        && currIdxBNList >= compositeNode.bNode.Count - 1
        && currIdxDN >= currDN.nodeList.Count) {
            Debug.Log("Completed composite node");

            if(compositeNode.linked) { // if composite node is linked, start next node
                Debug.Log("sdasdas");
                if(cNodeList.Count >= cNodeListIdx) {
                    cNodeListIdx++;
                    currIdxDN = 0; // resets dn idx counter
                    currIdxDNList = 0; // resets dn idx list counter
                    gameController.ChangeStates("Setup");
                }
            } else { // change to explore state
                gameController.ChangeStates("Explore");
            }
            return;
        }

        if(startDn && currIdxDN >= currDN.nodeList.Count) { // get next branch node
            currIdxDNList++;
            currBN = compositeNode.bNode[currIdxBNList];
            ShowOptions(currBN);
            startDn = false;
            currIdxDN = 0;
        }

        if(startDn && currIdxDNList >= 0 && currIdxDNList < compositeNode.dNode.Count) {
            if(currDN != null) {
                UpdateScreen();
            } else { Debug.LogError("Current DN is Null or empty");}
        }
    }

    public void ShowFirstDisplay() { // display first on state enter
        if(!compositeNode.startWithBranch) { // start with DN1
            if(compositeNode.dNode[0] != null) {
                currDN = compositeNode.dNode[0];
                UpdateScreen();
                startDn = true;
            } else { Debug.LogError("1st DN of CN empty"); }
        } else { // start with BN1
            if(compositeNode.bNode != null) {
                currBN = compositeNode.bNode[0];
                ShowOptions(currBN);
                inBranch = true;
            }
        }
    }

    private void UpdateScreen() {
        if(currIdxDN < currDN.nodeList.Count) {
            if(currDN.nodeList[currIdxDN].speaker == "Interrupt") {
                // do interrupt code
                currIdxDN++;
            }
            int idx = currIdxDN;
            nameBoxTxt.text = currDN.nodeList[idx].speaker;
            portraitController.SetPortrait(currDN.nodeList[idx].speaker, 0);
            bodyTxt.text = currDN.nodeList[idx].text;
            currIdxDN++;
        } else {Debug.LogError("Idx error");}
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
        
        inBranch = true;
    }

    public void Skip() { // shows last index of dn
        currIdxDN = currDN.nodeList.Count - 1;
        UpdateScreen();
    }
    
    public void Option1() {
        playerChoice = 1;
        currDN = compositeNode.bNode[currIdxBNList].dlist1;

        // deactivate UI
        dialogueOptionsObj.SetActive(false);
        
        // Show players reponse
        nameBoxTxt.text = "Bailey";
        bodyTxt.text = option1.text;

        currIdxBNList++;
    }

    public void Option2() {
        playerChoice = 2;
        currDN = compositeNode.bNode[currIdxBNList].dlist2;

        // deactivate UI
        dialogueOptionsObj.SetActive(false);
        
        // Show players reponse
        nameBoxTxt.text = "Bailey";
        bodyTxt.text = option2.text;

        currIdxBNList++;
    }
    
    public void Option3() {
        playerChoice = 3;
        currDN = compositeNode.bNode[currIdxBNList].dlist3;

        // deactivate UI
        dialogueOptionsObj.SetActive(false);
        
        // Show players reponse
        nameBoxTxt.text = "Bailey";
        bodyTxt.text = option3.text;

        currIdxBNList++;
    }
}
