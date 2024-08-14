using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Emotion
{
    Neutral,
    Happy,
    Sad
}

[CreateAssetMenu(menuName = "Dialogue System/Dialogue Node")]
public class DialogueNode : Node
{
    public string speakerName;
    public string dialogueText;
    public Emotion emotion;
    private string assetName;

    public void SetAssetName(string name) {
        assetName = name;
    }

    public void FillNode(string speaker, string emotionStr, string message) {
        nodeType = NodeType.Dialogue;
        speakerName = speaker;
        dialogueText = message;

        switch(emotionStr) {
            case "Happy":
                emotion = Emotion.Happy;
                break;
            default:
                emotion = Emotion.Neutral;
                break;
        }

        UnityEditor.AssetDatabase.CreateAsset(this, "Assets/Scripts/Dialogue/ScriptableObjects/" + this.assetName + ".asset");
        Debug.Log("Created: " + assetName);
    }
}