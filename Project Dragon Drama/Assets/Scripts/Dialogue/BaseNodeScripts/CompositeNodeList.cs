using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Node", menuName = "Node/Create Composite Node List")]
public class CompositeNodeList : ScriptableObject
{
    [SerializeField] public List<CompositeNode> nodeList = new List<CompositeNode>();
}
