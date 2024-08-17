using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue System/Auto Branch Node")]
public class AutoBranchNode : Node
{
    public NodeList nl1;
    public NodeList nl2;
    public string flagName;
    private string assetName;

    public void Init(string name) {
        nl1 = new NodeList();
        nl2 = new NodeList();
        assetName = name;
        nodeType = NodeType.AutoBranch;
    }

    public void SetFlag(string flagStr) {
        flagName = flagStr;

        UnityEditor.AssetDatabase.CreateAsset(this, "Assets/Scripts/Dialogue/ScriptableObjects/" + this.assetName + ".asset");
        Debug.Log("Created: " + assetName);
    }
}