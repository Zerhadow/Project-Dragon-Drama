// using UnityEngine;
// using System.IO;

// public class DialogueManager : MonoBehaviour
// {
//     public TextAsset dialogueJson; // Reference to your JSON file

//     private void Start()
//     {
//         if (dialogueJson != null)
//         {
//             // Get the path to a temporary file for storing the converted JSON
//             string tempFilePath = Path.Combine(Application.persistentDataPath, "temp.json");

//             // Convert the text file to JSON
//             WordToJSONConverter.ConvertToJSON(dialogueJson.text, tempFilePath);

//             // Read the JSON file and parse the dialogue            
//             string jsonText = dialogueJson.text;
//             DialogueData dialogueData = JsonUtility.FromJson<DialogueData>(jsonText);

//             // Now you can access the dialogueData object to get your character dialogue
//             foreach (var dialogueEntry in dialogueData.dialogue)
//             {
//                 Debug.Log($"{dialogueEntry.character}: {dialogueEntry.text}");
//             }
//         }
//         else
//         {
//             Debug.LogError("No dialogue JSON file assigned!");
//         }
//     }
// }

// [System.Serializable]
// public class DialogueData
// {
//     public DialogueEntry[] dialogue;
// }

// [System.Serializable]
// public class DialogueEntry
// {
//     public string character;
//     public string text;
// }