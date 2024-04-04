using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

// Put all dialogue up until a branch into here

[CreateAssetMenu(fileName ="Node", menuName = "Node/Create Dialogue Node List")]
public class SceneNode : ScriptableObject
{
    [SerializeField] public List<CompositeNode> nodeList = new List<CompositeNode>();
}
