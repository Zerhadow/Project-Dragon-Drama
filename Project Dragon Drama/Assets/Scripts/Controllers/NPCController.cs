using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class NPCController : MonoBehaviour 
{ 
    public GameObject pressETextBox;
    public PlayerController pc;

    [Header("NPC Dialogue Variables")] 
    public List<NodeList> dialogueNodeLists = new List<NodeList>();
    public int nodeIdx = 0;
    public bool talkedToToday = false; // if talked to NPC today, give other dialogue 

    private void OnTriggerEnter(Collider other) { 
        // check if player is between two collisions 

        if(other.tag == "Player") {
            // make player face npc when talking to them

            // set who the player is in range of
            pc.npc = this;

            Debug.Log("Player in talking range of " + other.name); 
            pressETextBox.SetActive(true);
        } 
    } 

    private void OnTriggerExit(Collider other) { 
        if(other.tag == "Player") {
            // reset composite list for dialogue controller 

            pc.npc = null;
            // dc.compositeNode = null;

            Debug.Log("Player in talking range of " + other.name); 
            pressETextBox.SetActive(false); 
        } 
    } 
} 
