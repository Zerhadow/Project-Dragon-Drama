using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;

public class WordToJSONConverter1 : MonoBehaviour
{  
    public class DialogueEntry {
        public string speaker;
        public string text;
        public List<DialogueOption> options;
    }

    public class DialogueOption {
        public string identifier;
        public string text;
        public List<DialogueResponse> responses;
    }

    public class DialogueResponse {
        public string speaker;
        public string text;
    }

    enum Speakers {
        Player,
        NPC
    }
    
    public string inputFilePath;
    
    void Awake() {
        if (inputFilePath != null) {
            StreamReader reader = new StreamReader(inputFilePath);
            Debug.Log(reader.ReadToEnd());
            reader.Close();
            // ConvertToJSON(inputFilePath);
        } else {
            Debug.LogError("No input file path specified");
        }
    }

    public void ReadFile() {

    }

    public static void ConvertToJSON(string inputFilePath) {
        List<DialogueEntry> dialogueEntries = new List<DialogueEntry>();

        string[] lines = System.IO.File.ReadAllLines(inputFilePath);

        DialogueEntry currentEntry = null;
        DialogueOption currentOption = null;

        foreach (string line in lines) {
            if (string.IsNullOrEmpty(line)) {
                continue;
            }

            if (line.StartsWith("Player:") || line.StartsWith("NPC:")) //find a way to not hardcode whos speaking
            {
                // Start of a new dialogue entry
                if (currentEntry != null)
                {
                    dialogueEntries.Add(currentEntry);
                }

                currentEntry = new DialogueEntry
                {
                    speaker = line.Trim(),
                    options = new List<DialogueOption>()
                };

                continue;
            }

            if (line.StartsWith("1 ->") || line.StartsWith("2 ->"))
            {
                // Start of a new option
                if (currentOption != null)
                {
                    currentEntry.options.Add(currentOption);
                }

                currentOption = new DialogueOption
                {
                    identifier = line.Substring(0, 1),
                    text = line.Substring(4).Trim(),
                    responses = new List<DialogueResponse>()
                };

                continue;
            }

            if (line.StartsWith("Option"))
            {
                // Start of a new response
                DialogueResponse response = new DialogueResponse
                {
                    speaker = "Player",
                    text = line.Substring(line.IndexOf(":") + 1).Trim()
                };

                currentOption.responses.Add(response);
            }
            else if (currentOption != null)
            {
                // Continue adding lines to the current response
                currentOption.responses[currentOption.responses.Count - 1].text += " " + line.Trim();
            }
        }
        // Add the last entry and option
        if (currentEntry != null)
        {
            dialogueEntries.Add(currentEntry);
        }

        PrintList(dialogueEntries);

        // Convert to JSON
        // string jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(new { dialogue = dialogueEntries }, Newtonsoft.Json.Formatting.Indented);
    }

    public static void PrintList(List<DialogueEntry> dialogueEntries) {
        foreach (DialogueEntry entry in dialogueEntries) {
            Debug.Log(entry.speaker);
            Debug.Log(entry.text);
            foreach (DialogueOption option in entry.options) {
                Debug.Log(option.identifier);
                Debug.Log(option.text);
                foreach (DialogueResponse response in option.responses) {
                    Debug.Log(response.speaker);
                    Debug.Log(response.text);
                }
            }
        }
    }
}
