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
    // private bool _inBranch;
    
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
    
    // [MenuItem("Window/Do Something")]
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
                dialogueNodeList.AddNode(speaker, text, dialogueNodeList);
            }

            // Ex: "BRANCH START"
            if(fileLine.Trim().StartsWith("BRANCH START")) {
                // create Branch node
                // bNode = ScriptableObject.CreateInstance<BranchNodeList>();
                BranchNodeList bNodeList = ScriptableObject.CreateInstance<BranchNodeList>();;
                i = FillBranchNodeList(bNodeList, i);
            }
        }
    }

    private int FillBranchNodeList(BranchNodeList bNodeList, int idx) {
        for(int i = idx; i < fileLines.Count; i++) { 
            string fileLine = fileLines[i].Trim();

            if(fileLine.StartsWith("1 ->")) { // start of a new option
                string optionText = fileLine.Substring(4);
                Debug.Log("OT: " + optionText);
                bNodeList.options[0] = optionText; // null ref exception
            }

            if(fileLine.StartsWith("{")) { // checks for stat modification

            }
            
            if(fileLine.Trim().StartsWith("BRANCH END")) { 
                // possible make into so
                // bNodeList = ScriptableObject.CreateInstance<BranchNodeList>();
                return i;
            }
        }
        
        return 0;
    }

    private void DebugPrint() {
        foreach (string fileLine in fileLines) {
            Debug.Log(fileLine);
        }
    }
}
