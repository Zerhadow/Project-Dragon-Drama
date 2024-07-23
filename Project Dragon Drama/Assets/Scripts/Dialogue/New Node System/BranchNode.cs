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

    public override NodeContent GetContent() {
        return new NodeContent
        {
            opt1 = opt1txt,
            opt2 = opt2txt,
            opt3 = opt3txt,
            option1NodeList = option1,
            option2NodeList = option2,
            option3NodeList = option3
        };
    }
}