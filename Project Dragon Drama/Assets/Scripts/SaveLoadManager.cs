using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    //public LinkedListNode head;
    //private LinkedList<LinkedListNode> linkedList;
    private string filePath;

    void Start()
    {
        filePath = Application.persistentDataPath + "/data.txt";
    }

    public void SaveData()
    {
        LinkedList<string> data = new LinkedList<string>();
        data.AddLast("PlayerName: Player 1");
        data.AddLast("PlayerScore: 100");

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (string item in data)
            {
                writer.WriteLine(item);
            }
        }

        Debug.Log("Data saved to: " + filePath);
    }

    public void LoadData()
    {
        if (File.Exists(filePath))
        {
            LinkedList<string> loadedData = new LinkedList<string>();

            // reading
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    loadedData.AddLast(line);
                }
            }

            // debug log
            foreach (string item in loadedData)
            {
                Debug.Log(item);
            }
        }
        else
        {
            Debug.LogWarning("No data file found at: " + filePath);
        }
    }

    /*
    public void SaveLinkedListToFile()
    {
        File.WriteAllText("data.txt", string.Empty); // overwrite?
        using (StreamWriter writer = new StreamWriter("data.txt"))
        {
            LinkedListNode current = head;
            while (current != null)
            {
                writer.WriteLine(current.data + "," + current.stat);
                current = current.next;
            }
        }

        Debug.Log("Saving data to file.");
    }

    public void LoadLinkedListFromFile()
    {
        head = null; // Clear previous data
        if (File.Exists("data.txt"))
        {
            string[] lines = File.ReadAllLines("data.txt");
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                string data = parts[0];
                int stat = int.Parse(parts[1]);

                // Add loaded data to the linked list
                AddNode(data, stat);
            }
        }

        PrintLinkedList();

        Debug.Log("Loading data from file.");
    }

    public void AddNode(string newData, int newStat)
    {
        LinkedListNode newNode = new LinkedListNode(newData, newStat);
        newNode.next = head;
        head = newNode;
    }

    public void ModifyLinkedListValues()
    {
        if (head != null)
        {
            head.data = "NewData";
            head.stat = 100;
        }

        Debug.Log("Linked list values modified.");
    }

    public void PrintLinkedList()
    {
        LinkedListNode current = head;
        while (current != null)
        {
            Debug.Log("Data: " + current.data + ", Stat: " + current.stat);
            current = current.next;
        }
    }
}

public class LinkedListNode
{
    public string data;
    public int stat;
    public LinkedListNode next;

    public LinkedListNode(string newData, int newStat)
    {
        data = newData;
        stat = newStat;
        next = null;
    }
    */
}
