using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue System/Node List")]
public class NodeList : ScriptableObject
{
    public bool linked = false;
    public bool advanceTime = false;
    
    public List<Node> nodes = new List<Node>();
    [HideInInspector] public string assetName;


    public void Init(string name) {
        nodes = new List<Node>();
        assetName = name;
    }
}
