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
    private string assetName;

    public void Init(string name) {
        nodeList = new List<DialogueNode>();
        assetName = name;
    }

    public int FillDialogueNodeList(List<string> fileLines, int idx) {
        for(int i = idx; i < fileLines.Count; i++) { 
            string fileLine = fileLines[i].Trim();
            
            if(string.IsNullOrEmpty(fileLines[i].Trim())) {
                continue;
            }

            if (fileLines[i].Trim().EndsWith(':')) { // A speaker is about to say something 
                string speaker = fileLine.Trim().Trim(':');
                string text = fileLines[++i].Trim();
                DialogueNode dNode = new DialogueNode
                {
                    speaker = speaker,
                    text = text
                };
                nodeList.Add(dNode);
            }

            if(fileLines[i].Trim().StartsWith("BEGIN BRANCH")
            || fileLines[i].Trim().StartsWith("END DNL")
            || fileLines[i].Trim().StartsWith("BDN")) { 
                UnityEditor.AssetDatabase.CreateAsset(this, "Assets/Scripts/Dialogue/ScriptableObjects/" + this.assetName + ".asset");
                Debug.Log("Created: " + assetName);
                // Debug.Log("Exit idx txt: " + fileLines[i].Trim());
                return i;
            }
        }

        return 0;
    }
}
