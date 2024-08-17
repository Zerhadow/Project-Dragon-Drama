using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue System/Stat Node")]
public class StatNode : Node
{
    public string statType;
    public int amount;
    private string assetName;

    public void SetNode(string name, string type, string modifier) {
        assetName = name.Trim();
        statType = type;
        amount = int.Parse(modifier);

        UnityEditor.AssetDatabase.CreateAsset(this, "Assets/Scripts/Dialogue/ScriptableObjects/" + this.assetName + ".asset");
        Debug.Log("Created: " + assetName);
    }
}
