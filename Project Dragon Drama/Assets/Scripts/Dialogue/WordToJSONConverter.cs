using System;
using System.Collections.Generic;
using System.IO;

public class WordToJSONConverter
{
    public class DialogueEntry
    {
        public string character;
        public string text;
    }

    public static void ConvertToJSON(string inputFilePath, string outputFilePath)
    {
        List<DialogueEntry> dialogueEntries = new List<DialogueEntry>();

        string[] lines = File.ReadAllLines(inputFilePath);

        DialogueEntry currentEntry = null;

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                // Skip empty lines
                continue;
            }

            if (line.Contains("    "))
            {
                // Assume lines with 4 spaces are dialogue text
                currentEntry.text += line.Trim() + " ";
            }
            else
            {
                // Assume other lines are character names
                currentEntry = new DialogueEntry
                {
                    character = line.Trim(),
                    text = ""
                };
                dialogueEntries.Add(currentEntry);
            }
        }

        // Convert to JSON manually
        using (StreamWriter writer = new StreamWriter(outputFilePath))
        {
            writer.WriteLine("{");
            writer.WriteLine("  \"dialogue\": [");

            for (int i = 0; i < dialogueEntries.Count; i++)
            {
                DialogueEntry entry = dialogueEntries[i];
                writer.WriteLine("    {");
                writer.WriteLine($"      \"character\": \"{entry.character}\",");
                writer.WriteLine($"      \"text\": \"{entry.text.Trim()}\"");
                writer.Write("    }");

                if (i < dialogueEntries.Count - 1)
                {
                    writer.WriteLine(",");
                }
                else
                {
                    writer.WriteLine();
                }
            }

            writer.WriteLine("  ]");
            writer.WriteLine("}");
        }
    }

    public static void Main()
    {
        string inputFilePath = "path/to/your/input.txt";
        string outputFilePath = "path/to/your/output.json";

        ConvertToJSON(inputFilePath, outputFilePath);

        Console.WriteLine("Conversion completed successfully.");
    }
}