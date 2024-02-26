using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ImportFile : MonoBehaviour
{
    [System.Serializable]
    public class DialogueEntry {
        public string speaker;
        public string text;
        public List<DialogueOption> options;
    }

    [System.Serializable]
    public class DialogueOption
    {
        public string identifier;
        public string text;
        public List<DialogueEntry> responses;
    }
    
    public string inputFilePath; // may turn into list of file paths
    List<string> fileLines = new List<string>();
    [SerializeField] public List<DialogueEntry> dialogueNodes = new List<DialogueEntry>();
    
    void Awake() {
        //may make foreach for each file path
        if (inputFilePath != null) {
            ReadFile(); //results in a filled fileLines list
        } else {
            Debug.LogError("No input file path specified");
        }

        // interpret fileLines list
        CreateNode(fileLines);
        // InterpretList(fileLines);
    }

    public void ReadFile() {
        StreamReader reader = new StreamReader(inputFilePath);
        string line;
        while ((line = reader.ReadLine()) != null) {
            fileLines.Add(line);
        }
        // print fileLines
        // foreach (string fileLine in fileLines) {
        //     Debug.Log(fileLine);
        // }
        reader.Close();
    }

    public void InterpretList(List<string> fileLines) {
        List<DialogueEntry> dialogueEntries = new List<DialogueEntry>();

        DialogueEntry currentEntry = null;
        DialogueOption currentOption = null;

        for(int i = 0; i < fileLines.Count; i++) {
            string fileLine = fileLines[i];

            if(string.IsNullOrEmpty(fileLine)) {
                continue;
            }

            if (fileLine.Trim().EndsWith(':')) // if the line ends with a colon, it's a speaker
            {
                // Start of a new dialogue entry
                if (currentEntry != null)
                {
                    dialogueEntries.Add(currentEntry);
                }

                currentEntry = new DialogueEntry
                {
                    speaker = fileLine.Trim().Trim(':'),
                };

                // print each dialogue entry
                Debug.Log(currentEntry.speaker + ": " + currentEntry.text);

                continue;
            }

            if(fileLine.StartsWith("1 ->") || fileLine.StartsWith("2 ->") || fileLine.StartsWith("3 ->")) {
                // start of a new option

                if(currentOption != null) { currentEntry.options.Add(currentOption); } // errors
                
                currentOption = new DialogueOption {
                    identifier = fileLine.Substring(0, 1),
                    text = fileLine.Substring(4).Trim(),
                    responses = new List<DialogueEntry>()
                };

                continue;
            }

            if(fileLine.StartsWith("Option")) {
                // start new entry based off the response
                DialogueEntry responseEntry = new DialogueEntry {
                    speaker = fileLine.Trim().Trim(':'),
                    text = fileLines[++i],
                };

                currentOption.responses.Add(responseEntry);
            } else if (currentOption != null) {
                // continue adding lines to the current response
                
            }

            if (currentEntry == null)
            {
                Debug.LogError("Dialogue file is not formatted correctly");
                return;
            }
        }

        // Add the last entry and option
        
    }

    public void CreateNode(List<string> fileLines) {

        DialogueEntry currentEntry = null;

        for(int i = 0; i < fileLines.Count; i++) {
            string fileLine = fileLines[i]; //reads current line

            if(string.IsNullOrEmpty(fileLine)) { // ignores whitespace between words
                continue;
            }

            if (fileLine.Trim().EndsWith(':')) // if the line ends with a colon, it's a speaker
            {
                // Start of a new dialogue entry
                if (currentEntry != null)
                {
                    dialogueNodes.Add(currentEntry);
                }

                currentEntry = new DialogueEntry
                {
                    speaker = fileLine.Trim().Trim(':'),
                };

                continue;
            } else {
                currentEntry.text += fileLine.Trim() + " ";
            }

            // print each dialogue entry
            // Debug.Log(currentEntry.speaker + ": " + currentEntry.text);
        }

        // Add last entry
        if (currentEntry != null)
        {
            dialogueNodes.Add(currentEntry);
        }

        // Debug.Log(dialogueNodes.Count);
    }

    public void ReadList(List<string> fileLines) {

        DialogueEntry currentEntry = null;

        for(int i = 0; i < fileLines.Count; i++) {
            string fileLine = fileLines[i]; //reads current line

            if(string.IsNullOrEmpty(fileLine)) { // ignores whitespace between words
                continue;
            }

            if (fileLine.Trim().EndsWith(':')) // if the line ends with a colon, it's a speaker
            {
                // Start of a new dialogue entry
                if (currentEntry != null)
                {
                    dialogueNodes.Add(currentEntry);
                }

                currentEntry = new DialogueEntry
                {
                    speaker = fileLine.Trim().Trim(':'),
                };

                continue;
            } else if(fileLine.Trim().StartsWith("Start Branch")) { //starts branch procedures
                
            } 
            
            else {
                currentEntry.text += fileLine.Trim() + " ";
            }

            // print each dialogue entry
            // Debug.Log(currentEntry.speaker + ": " + currentEntry.text);
        }

        // Add last entry
        if (currentEntry != null)
        {
            dialogueNodes.Add(currentEntry);
        }

        Debug.Log(dialogueNodes.Count);
    }

    public void CreateResponse(List<string> fileLines, int listIdxStart, int listIdxEnd) {
        DialogueEntry currentEntry = null;
        DialogueOption currentOption = null;

        for(int i = listIdxStart; i < fileLines.Count; i++) {
            string fileLine = fileLines[i];
        
            if(fileLine.StartsWith("1 ->") || fileLine.StartsWith("2 ->") || fileLine.StartsWith("3 ->")) { // start of a new option

                if(currentOption != null) { currentEntry.options.Add(currentOption); }
                
                currentOption = new DialogueOption {
                    identifier = fileLine.Substring(0, 1),
                    text = fileLine.Substring(4).Trim(),
                    responses = new List<DialogueEntry>()
                };

                continue;
            }

            // if(fileLine.StartsWith("Option")) {
            //     // start new entry based off the response
            //     DialogueEntry responseEntry = new DialogueEntry {
            //         speaker = fileLine.Trim().Trim(':'),
            //         text = fileLines[++i],
            //     };
            //     currentOption.responses.Add(responseEntry);
            // }
        }
    }
}
