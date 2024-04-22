using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Node", menuName = "Node/Create Composite Node")]
public class CompositeNode : ScriptableObject
{
    // public ConnectNode connectNode;
    [SerializeField] public bool startWithBranch;
    [SerializeField] public List<DialogueNodeList> dNode;
    [SerializeField] public List<BranchNode> bNode;

    // public void Init() {
    //     dNodeList = new DialogueNodeList();
    //     bNode = new BranchNode();
    // }

    // public void FillNode(DialogueNodeList dialogueNodeList, BranchNode bNode) {
    //     if(dialogueNodeList != null) {
    //         dNodeList = dialogueNodeList;
    //     } else if(bNode != null) {
    //         this.bNode = bNode;
    //     } else {
    //         Debug.LogError("Either both parameters for cnode are null or full");
    //     }
    // }
}
