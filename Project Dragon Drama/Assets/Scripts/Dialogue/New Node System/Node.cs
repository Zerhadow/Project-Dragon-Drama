using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeType {
    Dialogue,
    Branch,
    Quest
}

public class NodeContent {
    public string speakerName;
    public string bodyText;
    public Emotion emotion;
    public string opt1,opt2,opt3;
    public NodeList option1NodeList;
    public NodeList option2NodeList;
    public NodeList option3NodeList;
}

[CreateAssetMenu(menuName = "Dialogue System/Node")]
public abstract class Node : ScriptableObject
{
    public NodeType nodeType;

    // Abstract method for handling node functionality
    public abstract NodeContent GetContent();
}
