using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatType {
    Nerd,
    Persuasion,
    Manipulation,
    Deception
}

[CreateAssetMenu(menuName = "Dialogue System/Stat Node")]
public class StatNode : Node
{
    public StatType statType;
    public int amount;
}
