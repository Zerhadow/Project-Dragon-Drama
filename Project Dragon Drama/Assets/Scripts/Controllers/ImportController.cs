using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Palmmedia.ReportGenerator.Core.Reporting.Builders.Rendering;
using UnityEditor;
using UnityEngine;
using System;

public class ImportController : MonoBehaviour
{        
    [MenuItem("Node/Import Files [Newer]")]
    static void Import() {
        // add fill path
        List<string> inputFilePaths = new List<string>();

        inputFilePaths.Add("Assets/Narrative/Test Files/Test 1 - Create Nodelist with DNL.txt");

        
        # region Completed files
        // use text file 2 to compare formats
        // inputFilePaths.Add("Assets/Narrative/Dialogue_txt/Script_W1_D1_S1.txt");
        // inputFilePaths.Add("Assets/Narrative/Dialogue_txt/Script_W1_D1_S2.txt");
        // inputFilePaths.Add("Assets/Narrative/Dialogue_txt/Script_W1_D1_S3.txt");
        // inputFilePaths.Add("Assets/Narrative/Dialogue_txt/Script_W1_D1_S4.txt");

        #endregion

        // inputFilePaths.Add("Assets/Narrative/Dialogue_txt/Script_W1_D1_S5.txt");
        // inputFilePaths.Add("Assets/Narrative/Dialogue_txt/Script_W1_D2_S1.txt");
        // inputFilePaths.Add("Assets/Narrative/Dialogue_txt/Script_W1_D2_S2.txt");
        // inputFilePaths.Add("Assets/Narrative/Dialogue_txt/Script_W1_D3_S1.txt");
        // inputFilePaths.Add("Assets/Narrative/Dialogue_txt/Script_W1_D3_S2.txt");
        // inputFilePaths.Add("Assets/Narrative/Dialogue_txt/Quest_IntroQuest_W1_D0_S1.txt");
        // inputFilePaths.Add("Assets/Narrative/Dialogue_txt/Gossip_Janitor_W1_D0_S1.txt");
        // inputFilePaths.Add("Assets/Narrative/Dialogue_txt/Gossip_HistoryTeacher_W1_D0_S1.txt");

        // read file
        foreach (string filePath in inputFilePaths) {
            if( filePath != null) {
                List<string> fileLines = ReadFile(filePath);
                // DebugPrint(fileLines);
                // create objs from fileLines
                InterpretStringList(fileLines);
                Debug.Log("Finished import of " + fileLines);
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
        NodeList nl = ScriptableObject.CreateInstance<NodeList>();

        for(int i = 0; i < fileLines.Count; i++) { 
            if(string.IsNullOrEmpty(fileLines[i])) {
                continue;
            }

            if(fileLines[i].Trim().StartsWith("START NL")) {
                if(null == null) {
                    nl = ScriptableObject.CreateInstance<NodeList>();
                }
                // get name of node
                string name  = fileLines[++i].Trim();
                // Debug.Log("Name: " + name);

                Debug.Log("Name: " + name);
                nl.Init(name);
            }

            if(fileLines[i].Trim().StartsWith("BEGIN DNL")) { 
                DialogueNode dNode = ScriptableObject.CreateInstance<DialogueNode>();
                // get name of node
                string name  = fileLines[++i].Trim();
                // Debug.Log("Name: " + name);
                dNode.SetAssetName(name);
                // fill node & update idx i
                dNode.FillNode(fileLines[++i], fileLines[++i], fileLines[++i].Trim());
                nl.nodes.Add(dNode);
            }

            if(fileLines[i].Trim().StartsWith("BEGIN BNL")) {
                BranchNode2 bNode = ScriptableObject.CreateInstance<BranchNode2>();
                // get name of node
                string name  = fileLines[++i].Trim();
                bNode.Init(name);

                // get options strings
                string opt1 = "", opt2 = "", opt3 = "";

                // Debug.Log("txt: " + fileLines[++i].Trim());

                if(fileLines[++i].Trim().StartsWith("1 ->")) {
                    opt1 = fileLines[i].Trim().Substring(4);
                    // Debug.Log(opt1);
                }

                if(fileLines[++i].Trim().StartsWith("2 ->")) {
                    opt2 = fileLines[i].Trim().Substring(4);
                    // Debug.Log(opt2);
                }

                if(fileLines[++i].Trim().StartsWith("3 ->")) {
                    opt3 = fileLines[i].Trim().Substring(4);
                    // opt3 = fileLines[i].Trim().Substring(4);
                }

                bNode.FillOption(opt1, opt2, opt3);
                
                // fill node & update idx i
                // Debug.Log("enter text: " + fileLines[i].Trim());
                // i = bNode.FillBranchNode(fileLines, i, cNodeList);
                // Debug.Log("exit text: " + fileLines[i].Trim());
            }

            if(fileLines[i].Trim().StartsWith("END NL")) {
                UnityEditor.AssetDatabase.CreateAsset(nl, "Assets/Scripts/Dialogue/ScriptableObjects/" + nl.assetName + ".asset");
                Debug.Log("Created: " + nl.assetName);
            }
        }
    }

    private void DebugPrint(List<string> fileLines) {
        foreach (string fileLine in fileLines) {
            Debug.Log(fileLine);
        }
    }
}
