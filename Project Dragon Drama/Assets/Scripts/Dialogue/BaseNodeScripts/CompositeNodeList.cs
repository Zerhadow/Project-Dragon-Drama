using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Node", menuName = "Node/Create Composite Node List")]
public class CompositeNodeList : ScriptableObject
{
    [SerializeField] public List<CompositeNode> nodeList = new List<CompositeNode>();
    private string assetName;
    private int idx; // keeps track of asset number

    public void Init(string name) {
        nodeList = new List<CompositeNode>();
        assetName = name;
    }

    public void CreateCompositeNode() {
        CompositeNode cNode = ScriptableObject.CreateInstance<CompositeNode>();
        string name = assetName + idx;
    }
}
