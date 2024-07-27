using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeType {
    Dialogue,
    Branch,
    AutoBranch
}

public class NodeContent {
    public string speakerName;
    public string bodyText;
    public Emotion emotion;
    public string opt1,opt2,opt3;
    public NodeList option1NodeList;
    public NodeList option2NodeList;
    public NodeList option3NodeList;
    public NodeList nodeList1;
    public NodeList nodeList2;
}

[CreateAssetMenu(menuName = "Dialogue System/Node")]
public abstract class Node : ScriptableObject
{
    public NodeType nodeType;
}
