using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue System/Auto Branch Node")]
public class AutoBranchNode : Node
{
    public NodeList nl1;
    public NodeList nl2;
    public string flagName;
}