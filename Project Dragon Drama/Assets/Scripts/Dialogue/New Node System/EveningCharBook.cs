using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue System/Evening Char Book")]
public class EveningCharBook : ScriptableObject
{
    public int chapterNum;
    public List<NodeList> charNodes = new List<NodeList>();
    [HideInInspector] public string assetName;
    
    public void Init(string name) {
        charNodes = new List<NodeList>();
        assetName = name;
    }
}
