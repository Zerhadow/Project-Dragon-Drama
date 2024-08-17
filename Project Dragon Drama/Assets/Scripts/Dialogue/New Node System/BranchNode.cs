using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue System/Branch Node")]
public class BranchNode : Node
{
    public string opt1txt,opt2txt,opt3txt;
    public NodeList option1;
    public NodeList option2;
    public NodeList option3;
    public string assetName;

    public void Init(string name) {
        opt1txt = "";
        opt2txt = "";
        opt3txt = "";
        option1 = new NodeList();
        option2 = new NodeList();
        option3 = new NodeList();
        assetName = name;
        nodeType = NodeType.Branch;
    }

    public int CreateNodeList(List<string> fileLines, int idx, int nlIdx) {
        NodeList nl = ScriptableObject.CreateInstance<NodeList>();

        // Debug.Log("Attempt " + nlIdx);

        for(int i = idx; i < fileLines.Count; i++) { 
            if(fileLines[i].Trim().StartsWith("START NL")) {
                if(nl == null) {
                    nl = ScriptableObject.CreateInstance<NodeList>();
                }
                // get name of node
                string name  = fileLines[++i].Trim();
                // Debug.Log("Name: " + name);

                // Debug.Log("Name: " + name);
                nl.Init(name);
            }

            if(fileLines[i].Trim().StartsWith("BEGIN DNL")) { 
                DialogueNode dNode = ScriptableObject.CreateInstance<DialogueNode>();
                // get name of node
                string name  = fileLines[++i].Trim();
                // Debug.Log("Name: " + name);
                dNode.SetAssetName(name);
                // fill node & update idx i
                dNode.FillNode(fileLines[++i], fileLines[++i], fileLines[++i].Trim());
                nl.nodes.Add(dNode);
            }

            if(fileLines[i].Trim().StartsWith("END NL")) {
                UnityEditor.AssetDatabase.CreateAsset(nl, "Assets/Scripts/Dialogue/ScriptableObjects/" + nl.assetName + ".asset");
                Debug.Log("Created: " + nl.assetName);

                if(nlIdx == 0) {
                    this.option1 = nl;
                } else if(nlIdx == 1) {
                    this.option2 = nl;
                } else if(nlIdx == 2) {
                    this.option3 = nl;
                } else {
                    Debug.LogError("Node List index incorrect");
                }
            }

            return i;
        }

        return -1; // will be an error. should always exact at END NL
    }
}