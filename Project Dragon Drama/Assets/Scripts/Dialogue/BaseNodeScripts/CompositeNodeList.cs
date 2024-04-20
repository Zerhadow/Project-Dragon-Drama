using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Node", menuName = "Node/Create Composite Node List")]
public class CompositeNodeList : ScriptableObject
{
    [SerializeField] public List<CompositeNode> nodeList = new List<CompositeNode>();
    public string assetName;
    private int idx; // keeps track of asset number

    public void Init(string name) {
        nodeList = new List<CompositeNode>();
        assetName = name;
    }

    public void AddCompositeNode(DialogueNodeList dialogueNodeList, BranchNode bNode) {
        // Debug.Log("dnl: " + dialogueNodeList);
        // Debug.Log("bn: " + bNode);
        CompositeNode cNode = ScriptableObject.CreateInstance<CompositeNode>();
        cNode.Init();
        cNode.FillNode(dialogueNodeList, bNode);
        UnityEditor.AssetDatabase.CreateAsset(cNode, "Assets/Scripts/Dialogue/ScriptableObjects/" + this.assetName + " C_" + idx + ".asset");
        nodeList.Add(cNode);
    }
}
