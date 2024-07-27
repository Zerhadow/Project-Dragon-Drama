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
}
