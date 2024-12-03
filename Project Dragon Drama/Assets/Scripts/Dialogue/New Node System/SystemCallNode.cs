using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue System/System Call Node")]
public class SystemCallNode : Node
{
    public string action; // Will have a keyword that triggers when activated
}
