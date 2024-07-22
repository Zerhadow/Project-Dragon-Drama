using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue System/Node List")]
public class NodeList : ScriptableObject
{
    public List<Node> nodes = new List<Node>();
}
