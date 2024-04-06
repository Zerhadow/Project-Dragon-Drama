using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Node", menuName = "Node/Create Branch Node List")]
public class BranchNode : ScriptableObject
{
    public List<string> options;
    public DialogueNodeList dlist1;
    public DialogueNodeList dlist2;
    public DialogueNodeList dlist3;
    private string assetName;

    public void Init(string name) {
        options = new List<string>();
        dlist1 = new DialogueNodeList();
        dlist2 = new DialogueNodeList();
        dlist3 = new DialogueNodeList();
        this.assetName = name;
    }
    
    public void FillOption(string text1,string text2,string text3) {
        this.options.Add(text1);       
        this.options.Add(text2);

        if(text3 != null) {
            this.options.Add(text3);       
        }    
    }

    public int FillBranchNode(List<string> fileLines, int idx) {
        for(int i = idx; i < fileLines.Count; i++) {  
            string fileLine = fileLines[i].Trim();
            
            if(string.IsNullOrEmpty(fileLine)) {
                continue;
            }

            if(fileLine.StartsWith("BEGIN DIALOGUE NODE")) { 
                DialogueNodeList dNodeList1 = ScriptableObject.CreateInstance<DialogueNodeList>();
                // get name of node
                string name  = fileLines[++i].Trim();
                dNodeList1.Init(name);
                // fill node & update idx i
                i = dNodeList1.FillDialogueNodeList(fileLines, ++i);
                // add dNode to Branch
                this.dlist1 = dNodeList1;
                Debug.Log("text: " + fileLines[i].Trim());

                DialogueNodeList dNodeList2 = ScriptableObject.CreateInstance<DialogueNodeList>();
                // get name of node
                name  = fileLines[++i].Trim();
                dNodeList2.Init(name);
                // fill node & update idx i
                i = dNodeList2.FillDialogueNodeList(fileLines, ++i);
                // add dNode to Branch
                this.dlist2 = dNodeList2;

                // if(this.options.Count == 3) {
                //     i = dNodeList1.FillDialogueNodeList(fileLines, ++i);
                //     this.dlist3 = dNodeList1;
                // }
            }

            if(fileLine.StartsWith("END OF BRANCH")) {
                UnityEditor.AssetDatabase.CreateAsset(this, "Assets/Scripts/Dialogue/ScriptableObjects/" + this.assetName + ".asset");
                return i;
            }
        }

        return 0;
    }
}
