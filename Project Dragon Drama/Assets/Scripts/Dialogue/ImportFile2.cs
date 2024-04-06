using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Palmmedia.ReportGenerator.Core.Reporting.Builders.Rendering;
using UnityEditor;
using UnityEngine;

public class ImportFile2 : MonoBehaviour
{    
    public List<string> inputFilePaths;
    List<string> fileLines = new List<string>();
    [SerializeField] public List<DialogueNodeList> dialogueNodeLists = new List<DialogueNodeList>();
    
    void Awake() {
        // testing purposes: Clear test node lists before running script
        
        foreach (string filePath in inputFilePaths) {
            if( filePath != null) {
                ReadFileToList(filePath);
                foreach(DialogueNodeList list in dialogueNodeLists) {
                    ImportToNodeList(list);
                }
            } else { Debug.LogError("No input file path specified");}
        }
    }

    public void ReadFileToList(string pathName) {
        StreamReader reader = new StreamReader(pathName);
        string line;

        while ((line = reader.ReadLine()) != null) {
            fileLines.Add(line);
        }

        reader.Close();
    }
    
    [MenuItem("Node/Import Files")]
    static void Import() {
        // add fill path
        List<string> inputFilePaths = new List<string>();
        inputFilePaths.Add("Assets/Narrative/Example DNodeList.txt");
        // inputFilePaths.Add("Assets/Narrative/Example BNodeList.txt");

        // read file
        foreach (string filePath in inputFilePaths) {
            if( filePath != null) {
                List<string> fileLines = ReadFile(filePath);
                // DebugPrint(fileLines);
                // create objs from fileLines
                InterpretStringList(fileLines);
            } else { Debug.LogError("No input file path specified");}
        }
    }

    private static List<string> ReadFile(string pathName) {
        List<string> fileLines = new List<string>();;
        StreamReader reader = new StreamReader(pathName);
        string line;

        while ((line = reader.ReadLine()) != null) {
            fileLines.Add(line);
        }

        reader.Close();
        return fileLines;
    }

    private static void InterpretStringList(List<string> fileLines) {
        for(int i = 0; i < fileLines.Count; i++) { 
            string fileLine = fileLines[i].Trim();

            if(string.IsNullOrEmpty(fileLine)) {
                continue;
            }

            if(fileLine.StartsWith("BEGIN DIALOGUE NODE")) { 
                DialogueNodeList dNodeList = ScriptableObject.CreateInstance<DialogueNodeList>();
                // get name of node
                string name  = fileLines[++i].Trim();
                dNodeList.Init(name);
                // fill node & update idx i
                i = dNodeList.FillDialogueNodeList(fileLines, i);
            }
        }
    }

    public void ImportToNodeList(DialogueNodeList dialogueNodeList) {
        for(int i = 0; i < fileLines.Count; i++) {
            // Debug.Log("Idx: " + i);
            string fileLine = fileLines[i];
            string fileLine2 = fileLines[++i]; // gets the corresponding text from speaker

            if(string.IsNullOrEmpty(fileLine)) {
                continue;
            }

            if (fileLine.Trim().EndsWith(':')) { // A speaker is about to say something 
                string speaker = fileLine.Trim().Trim(':');
                string text = fileLine2.Trim();
                // dialogueNodeList.AddNode(speaker, text, dialogueNodeList);
            }
        }
    }

    private void DebugPrint(List<string> fileLines) {
        foreach (string fileLine in fileLines) {
            Debug.Log(fileLine);
        }
    }
}
