using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue System/Branch Node")]
public class BranchNode : Node
{
    public string opt1txt,opt2txt,opt3txt;
    public NodeList option1;
    public NodeList option2;
    public NodeList option3;
}