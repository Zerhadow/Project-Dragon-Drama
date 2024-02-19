using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Node", menuName = "Node/Create Branch Node List")]
public class BranchNodeList : ScriptableObject
{
    [System.Serializable]
    public class BranchNode
    {
        public List<string> options;
        public DialogueNodeList dlist1;
        public DialogueNodeList dlist2;
        public DialogueNodeList dlist3;
    }

    [SerializeField] public List<BranchNode> nodeList;
}
