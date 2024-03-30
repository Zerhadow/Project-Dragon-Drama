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
                ImportToNodeList();
            } else { Debug.LogError("No input file path specified");}
        }
    }

    public void ReadFileToList(string pathName) {
        StreamReader reader = new StreamReader(pathName);
        string line;

        while ((line = reader.ReadLine()) != null) {
            fileLines.Add(line);
        }

        // DebugPrint();
        reader.Close();
    }
    
    // [MenuItem("Window/Do Something")]
    public void ImportToNodeList() {
        // DebugPrint();
        for(int i = 0; i < fileLines.Count; i++) {
            // Debug.Log("Idx: " + i);
            string fileLine = fileLines[i];
            string fileLine2 = fileLines[++i]; // gets the corresponding text from speaker
            // ignore the index error

            // create empty nodes
            DialogueNodeList dNode = null;
            BranchNodeList bNode = null;


            if(string.IsNullOrEmpty(fileLine)) {
                continue;
            }

            // Ex: "FOLDER"
            if(fileLine.Trim().StartsWith("FOLDER")) { // its not making folder
                // create folder
                Debug.Log("plz: " + fileLine2.Trim());
                if(fileLine2.Trim() != null) {
                    AssetDatabase.CreateFolder("Assets/Scripts/Dialogue/ScriptableObjects/", fileLine2.Trim());
                }
            }

            // Ex: "BEGIN DIALOGUE NODE"
            if(fileLine.Trim().StartsWith("BEGIN DIALOGUE NODE")) {
                // create Dialogue node
                dNode = ScriptableObject.CreateInstance<DialogueNodeList>();
                // get name of file
                if( fileLine2 != null && fileLine2.Trim().StartsWith("DNN")) {
                    string soName = fileLine2.Trim();
                    // Debug.Log("SO: " + soName);
                    // creates dialogue node
                    UnityEditor.AssetDatabase.CreateAsset(dNode, "Assets/Scripts/Dialogue/ScriptableObjects/" + soName + ".asset");
                }
            }
            
            // Ex: "Bailey:"
            if (fileLine.Trim().EndsWith(':')) { // A speaker is about to say something 
                string speaker = fileLine.Trim().Trim(':');
                string text = fileLine2.Trim();
                // dialogueNodeList.AddNode(speaker, text, dialogueNodeList);
            }

            // Ex: "BRANCH BEGINS"
            if(fileLine.Trim().StartsWith("BEGIN BRANCH NODE")) {
                // create Branch node
                bNode = ScriptableObject.CreateInstance<BranchNodeList>();
            }
        }
    }

    private void DebugPrint() {
        foreach (string fileLine in fileLines) {
            Debug.Log(fileLine);
        }
    }
}
