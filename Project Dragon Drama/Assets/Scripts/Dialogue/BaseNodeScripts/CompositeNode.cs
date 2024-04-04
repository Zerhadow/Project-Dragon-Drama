using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

// Put all dialogue up until a branch into here

public class CompositeNode : MonoBehaviour
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
