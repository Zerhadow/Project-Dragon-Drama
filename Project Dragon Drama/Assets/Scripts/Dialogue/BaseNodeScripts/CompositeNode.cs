using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Node", menuName = "Node/Create Composite Node")]
public class CompositeNode : ScriptableObject
{
    [SerializeField] public DialogueNodeList dNodeList;
    [SerializeField] public BranchNode bNode;
    // public ConnectNode connectNode;
}
