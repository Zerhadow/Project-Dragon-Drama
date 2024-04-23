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
        assetName = name;
    }
    
    public void FillOption(string text1,string text2,string text3) {
        options.Add(text1);       
        options.Add(text2);

        if(text3 != null) {
            options.Add(text3);       
        }    
    }

    public int FillBranchNode(List<string> fileLines, int idx, CompositeNodeList cNodeList) {
        for(int i = idx; i < fileLines.Count; i++) {  
            string fileLine = fileLines[i].Trim();
            
            if(string.IsNullOrEmpty(fileLine)) {
                continue;
            }

            if(fileLines[i].Trim().StartsWith("BEGIN DNL")) {
                // creates SOs
                DialogueNodeList dNodeList1 = ScriptableObject.CreateInstance<DialogueNodeList>();
                DialogueNodeList dNodeList2 = ScriptableObject.CreateInstance<DialogueNodeList>();
                DialogueNodeList dNodeList3 = ScriptableObject.CreateInstance<DialogueNodeList>(); // will stay empty if node third choice

                // initialize names for SOs
                string name, name2, name3;

                // get name of node
                name = fileLines[++i].Trim();
                dNodeList1.Init(name);

                // fill node & update idx i
                i = dNodeList1.FillDialogueNodeList(fileLines, ++i, null);

                // add dNode to Branch
                dlist1 = dNodeList1;
                // Debug.Log("text: " + fileLines[i].Trim());

                // get name of node
                name2  = fileLines[i++].Trim();
                dNodeList2.Init(name2);

                 // fill node & update idx i
                // Debug.Log("text: " + fileLines[i].Trim());
                i = dNodeList2.FillDialogueNodeList(fileLines, ++i, null);

                // add dNode to Branch
                dlist2 = dNodeList2;
                // Debug.Log("text: " + fileLines[i].Trim());

                if(options.Count == 3) {
                    // Debug.Log("text: " + fileLines[i].Trim());
                    
                    // get name of node
                    name3  = fileLines[i++].Trim();
                    dNodeList3.Init(name3);

                    // fill node & update idx i
                    i = dNodeList3.FillDialogueNodeList(fileLines, i, null);

                    // add dNode to Branch
                    dlist3 = dNodeList3;
                }

                if(fileLines[i].Trim() == "END BRANCH") {
                    // Debug.Log("text: " + fileLines[i].Trim());
                    UnityEditor.AssetDatabase.CreateAsset(this, "Assets/Scripts/Dialogue/ScriptableObjects/" + assetName + ".asset");
                    Debug.Log("Created: " + assetName);
                    return i;
                }
            }

            if(fileLines[i].Trim().StartsWith("END BRANCH") 
            || fileLines[i].Trim().StartsWith("END DNL")) {
                if(cNodeList != null) {
                    cNodeList.AddCompositeNode(null, this);
                }
                UnityEditor.AssetDatabase.CreateAsset(this, "Assets/Scripts/Dialogue/ScriptableObjects/" + assetName + ".asset");
                Debug.Log("Created: " + assetName);
                return i;
            }
        }

        return 0;
    }
}
