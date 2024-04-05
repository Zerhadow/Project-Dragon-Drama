using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Node", menuName = "Node/Create Branch Node List")]
public class BranchNodeList : ScriptableObject
{
    public List<string> options;
    public DialogueNodeList dlist1;
    public DialogueNodeList dlist2;
    public DialogueNodeList dlist3;

    public void Init() {
        options = new List<string>();
        dlist1 = new DialogueNodeList();
        dlist2 = new DialogueNodeList();
        dlist3 = new DialogueNodeList();
    }
    
    public void FillOption(int idx, string text) {
        this.options.Add(text);
    }
}
