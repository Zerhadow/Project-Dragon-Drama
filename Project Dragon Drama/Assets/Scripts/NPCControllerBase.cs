using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCControllerBase : MonoBehaviour
{
    [Header ("Required Objects")]
    [SerializeField] GameObject _npc;
    /*
    [SerializeField] GameObject _characterController;
    public GameObject pressETextBox;
    */
    private GameObject _characterController;
    private GameObject pressETextBox;

    [Header("NPC Vairables")]
    [SerializeField] bool _givesKeyGossip = false;
    [SerializeField] public string gossipText = "This is a test gossip text";

    private void Awake()
    {
        //Find and set object references
        _characterController = GameObject.Find("CharacterController");
        pressETextBox = GameObject.Find("PressE");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") //Player has entered talk range
        {
            _characterController.GetComponent<CharacterControllerBase>().setAdjacentNPC(_npc); //Set this NPC as adjacentNPC on Character Controller

            /*For Debug Tesing*/
            _npc.GetComponent<Renderer>().material.SetColor("_Color", Color.magenta);
            Debug.Log("Player in talking range of " + _npc.name);
            pressETextBox.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") //Player has exited talk range
        {
            _characterController.GetComponent<CharacterControllerBase>().setAdjacentNPC(null); //Set adjacentNPC as null on CharacterController

            /*For Debug Tesing*/
            _npc.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
            Debug.Log("Player has left talking range of " + _npc.name);
            pressETextBox.SetActive(false);
        }
    }

    public bool GiveKeyGossip ()
    {
        return _givesKeyGossip;
    }
}
