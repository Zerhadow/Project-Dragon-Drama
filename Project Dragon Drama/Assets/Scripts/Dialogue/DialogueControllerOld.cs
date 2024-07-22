using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueControllerOld : MonoBehaviour
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
    private int currIdxDNList = 0; // idx for composite dnode list
    private int currIdxBNList = 0; // idx for composite bnode list
    public int currIdxDN = 0; // idx for DN node list
    private int playerChoice = 0;
    private bool inBranch = false, startDn = false, startBn = false;

    public CompositeNode compositeNode;
    private int cNodeListIdx = 0;
    [SerializeField] public List<CompositeNode> cNodeList;
    private DialogueNodeList currDN; // current dialogue node sys is going through
    private BranchNode2 currBN; // current branch node sys is going through

    private void Awake() {
        dialogueOptionsObj.SetActive(false);
        gameController = GetComponentInParent<GameController>();
        portraitController = GetComponent<PortraitController>();
        SetCompositeNode(cNodeList[0]);
    }

    public void SetCompositeNode(CompositeNode node = null) {
        compositeNode = node ?? cNodeList[cNodeListIdx];
        // Debug.Log("Composite Node set to: " + compositeNode.name);
    }

    public void ReadCompositeNode() { // method to be called by btn press
        // Debug.Log("InBranch? " + inBranch);
        if (inBranch) { ProcessBranchNode(); }
        else { ProcessDialogueNode(); }
    }

    private void ProcessBranchNode() {
        // Debug.Log("CurrIdxDN: " + currIdxDN);
        // Debug.Log("Count: " + currDN.nodeList.Count);
        if (currIdxDN >= currDN.nodeList.Count) { EndBranchNode(); }
        else {
            if (CheckStatModifier(currDN.nodeList[currIdxDN].speaker)) {
                currIdxDN++;
            }
            UpdateScreen();
        }
    }

    private void EndBranchNode() {
        inBranch = false;
        startDn = true;
        // Debug.Log("CurrDN name: " + compositeNode.dNode[currIdxDNList]);
        if(compositeNode.dNode[currIdxDNList] != null) { // if there is a dNode after BNode dNode
            currDN = compositeNode.dNode[currIdxDNList];
            currIdxDN = 0;
            ProcessDialogueNode();
        } else {
            EndCompositeNode();
        }
    }

    private bool CheckStatModifier(string speaker) {
        if (speaker.Trim().StartsWith("+")) {
            statController.ApplyModifier(speaker.Trim());
            return true;
        }
        return false;
    }

    private void ProcessDialogueNode() {
        // Debug.Log("CurrIdxDN: " + currIdxDN);
        // Debug.Log("Count: " + currDN.nodeList.Count);
        if (IsEndOfCompositeNode()) { EndCompositeNode(); }
        else if (currIdxDN >= currDN.nodeList.Count) // at end of dialogue node, if theres a branch node next in queue play it
        {
            StartBranchNode();
        }
        else if (startDn && currIdxDNList >= 0 && currIdxDNList < compositeNode.dNode.Count)
        {
            UpdateScreen();
        }
    }

    private bool IsEndOfCompositeNode()
    {
        return currIdxDNList >= compositeNode.dNode.Count - 1
            && currIdxBNList >= compositeNode.bNode.Count
            && currIdxDN >= currDN.nodeList.Count;
    }

    private void EndCompositeNode() {
        Debug.Log("Completed composite node");
        if (compositeNode.advanceTime) {
            gameController.gameTimeController.AdvanceTime();
            Debug.Log("New time: " + gameController.gameTimeController.GetCurrentTimeOfDay());
        }

        if (compositeNode.linked && cNodeList.Count > cNodeListIdx) {
            cNodeListIdx++;
            ResetIndexes();
            SetCompositeNode();
        }

        gameController.ChangeStates("Explore");
        return;
    }

    private void ResetIndexes() {
        currIdxDN = 0;
        currIdxDNList = 0;
        currIdxBNList = 0;
    }

    private void StartBranchNode() {
        currIdxDNList++;
        currBN = compositeNode.bNode[currIdxBNList];
        ShowOptions(currBN);
        startDn = false;
        currIdxDN = 0;
    }

    public void ShowFirstDisplay() {
        if (!compositeNode.startWithBranch) { StartDialogueNode();
        } else { StartBranchNode(); }
    }

    private void StartDialogueNode() {
        if (compositeNode.dNode[0] != null) {
            currDN = compositeNode.dNode[0];
            UpdateScreen();
            startDn = true;
        } else {
            Debug.LogError("First Dialogue Node of Composite Node is empty");
        }
    }

    private void UpdateScreen() {
        if (currIdxDN < currDN.nodeList.Count) {
            ProcessDialogueContent();
        } else {
            Debug.LogError("Index out of range");
        }
    }

    private void ProcessDialogueContent() {
        if (currDN.nodeList[currIdxDN].speaker == "Interrupt") {
            // do interrupt code
            currIdxDN++;
        }

        int idx = currIdxDN;
        nameBoxTxt.text = currDN.nodeList[idx].speaker;
        portraitController.SetPortrait(currDN.nodeList[idx].speaker, 0);
        bodyTxt.text = currDN.nodeList[idx].text;
        currIdxDN++;
    }

    private void ShowOptions(BranchNode2 branchNode) {
        if (branchNode.options != null) 
        {
            SetupBranchNodeOptions(branchNode);
            inBranch = true;
        } 
        else 
        {
            Debug.LogError("Fill options list");
        }
    }

    private void SetupBranchNodeOptions(BranchNode2 branchNode) {
        if (branchNode.options.Count == 2) 
        {
            SetBranchNodeOptions(branchNode, false);
        } 
        else if (branchNode.options.Count == 3) 
        {
            SetBranchNodeOptions(branchNode, true);
        }
    }

    private void SetBranchNodeOptions(BranchNode2 branchNode, bool showThirdOption) {
        dialogueOptionsObj.SetActive(true);
        options3GameObj.SetActive(showThirdOption);

        option1.text = branchNode.options[0];
        option2.text = branchNode.options[1];
        if (showThirdOption) 
        {
            option3.text = branchNode.options[2];
        }
    }

    public void Skip() {
        currIdxDN = currDN.nodeList.Count - 1;
        UpdateScreen();
        // Debug.Log("Player skipped dialogue node contents");
    }

    public void Option1() {
        HandleOptionSelection(1, currBN.dlist1, option1.text);
    }

    public void Option2() {
        HandleOptionSelection(2, currBN.dlist2, option2.text);
    }

    public void Option3() {
        HandleOptionSelection(3, currBN.dlist3, option3.text);
    }

    private void HandleOptionSelection(int choice, DialogueNodeList dialogueList, string optionText) {
        playerChoice = choice;
        currDN = dialogueList;

        dialogueOptionsObj.SetActive(false);

        UpdateScreen();

        currIdxBNList++;
    }
}
