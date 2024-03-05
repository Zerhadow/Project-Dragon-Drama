using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [Header("Game System Dependencies")]
    public GameController gameController;
    public GameObject pressETextBox;
    [Header("NPC Dialogue Variables")]
    [SerializeField] public List<CompositeNode> nodeList = new List<CompositeNode>();
    bool talkedToToday = false; // if talked to NPC today, give other dialogue
    [SerializeField] public List<DialogueNodeList> list2 = new List<DialogueNodeList>();


    private void Awake() {
        // make player face the npc when talking to them
    }

    private void OnTriggerEnter(Collider other) {
        // check if player is between two collisions

        if(other.tag == "Player") {
            // set composite list for dialogue controller

            Debug.Log("Player in talking range of " + other.name);
            pressETextBox.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player") {
            // set composite list for dialogue controller

            Debug.Log("Player in talking range of " + other.name);
            pressETextBox.SetActive(false);
        }
    }
}
