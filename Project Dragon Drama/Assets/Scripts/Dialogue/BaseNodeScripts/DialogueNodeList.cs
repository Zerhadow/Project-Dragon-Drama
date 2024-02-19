using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

// Put all dialogue up until a branch into here

[CreateAssetMenu(fileName ="Node", menuName = "Node/Create Dialogue Node List")]
public class DialogueNodeList : ScriptableObject
{
    [System.Serializable]
    public class DialogueNode
    {
        public enum Emotion { // triggers different potrait img per emotion
            Neutral,
            Happy,
            Sad
        }
        public Emotion emotion;
        public string speaker;
        public string text;
    }

    public int idx = 0;

    [SerializeField] public List<DialogueNode> nodeList;
}
