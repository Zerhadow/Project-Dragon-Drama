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
    private string assetName;

    public void Init(string name) {
        option1 = new NodeList();
        option2 = new NodeList();
        option3 = new NodeList();
        assetName = name;
    }
}