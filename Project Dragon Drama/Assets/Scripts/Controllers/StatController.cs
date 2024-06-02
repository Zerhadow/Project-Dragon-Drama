using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatController : MonoBehaviour
{
    [Header("Player Stats")]
    public int nerd, persuasion, manipulation, deception;
    
    [Header("Player Stats with Ppl")]
    public int sam, persia, jassica, natalie, ken;

    public void ApplyModifier(string str) {
        // Split the modifier string into value and type
        string[] parts = str.Split(' ');

        string valueString = parts[0]; // "+ # where # is the number of points added"
        string typeString = parts[1]; // Stat or Relationship
        string lastWord = parts[parts.Length - 1]; // sam, persia, etc

        // Parse the modifier value
        if (!int.TryParse(valueString, out int value))
        {
            Debug.LogError("Invalid modifier value");
            return;
        }

        if(typeString == "Stat") {
            if(parts[2] != null) {
                switch(parts[2]) {
                    case "Nerd":
                        nerd += int.Parse(valueString.TrimStart('+'));
                        Debug.Log("Added: " + valueString + " to player");
                        break;
                }
            } else {Debug.LogError("Command doesnt say what stat to modifiy");}
        }

        if(typeString == "Relationship") {
            switch(lastWord) {
                case "Sam":
                    sam += int.Parse(valueString.TrimStart('+'));
                    Debug.Log("Added: " + valueString + "to player");
                    break;
                default:
                    Debug.LogError("Last word is invalid");
                    break;
            }
        }

    }
}
