using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Node", menuName = "Node/Create Composite Node")]
public class CompositeNode : ScriptableObject
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
