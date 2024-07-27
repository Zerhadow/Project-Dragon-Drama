using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeType {
    Dialogue,
    Branch,
    AutoBranch
}

[CreateAssetMenu(menuName = "Dialogue System/Node")]
public abstract class Node : ScriptableObject
{
    public NodeType nodeType;
}
