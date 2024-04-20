using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Palmmedia.ReportGenerator.Core.Reporting.Builders.Rendering;
using UnityEditor;
using UnityEngine;
using System;

public class importFile3 : MonoBehaviour
{
    [MenuItem("Node/Import Files new")]
    static void Import() {
        // add file path
        List<string> filePaths = new List<string>();
        filePaths.Add("Assets/Narrative/Dialogue_txt/Script_W1_D1_S1.txt");
        filePaths.Add("Assets/Narrative/Dialogue_txt/Script_W1_D1_S2.txt");
    
        // read file
        foreach (string filePath in filePaths) {
            if( filePath != null) {
                List<string> fileLines = ReadFile(filePath);
                // DebugPrint(fileLines);
                // create objs from fileLines
                // InterpretStringList(fileLines);
                Debug.Log("Finished import of " + filePath);
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

            if(fileLine.StartsWith("BEGIN DNL")) { 
                DialogueNodeList dNodeList = ScriptableObject.CreateInstance<DialogueNodeList>();
                // get name of node
                string name  = fileLines[++i].Trim();
                dNodeList.Init(name);
                // fill node & update idx i
                i = dNodeList.FillDialogueNodeList(fileLines, i);
            }
        }
    }
}
