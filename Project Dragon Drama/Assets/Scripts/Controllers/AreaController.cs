using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaController : MonoBehaviour
{
    public bool enteredHallway = false;
    
    void OnTriggerEnter(Collider other) {
        string otherTransformName = other.transform.name;

        // Debug.Log("Collided with: " + otherTransformName);
        
        if(other.tag == "Zone") {
            switch(otherTransformName) {
                case "Hallway":
                    Debug.Log("Player has entered hallway");
                    // inform player controller that player is in hallway
                    enteredHallway = true;
                    other.gameObject.SetActive(false); // hopefully the time stuff wont interfere with game progression
                    break;
                case "Hallway2":
                    Debug.Log("Player has entered hallway");
                    // inform player controller that player is in hallway
                    enteredHallway = true;
                    break;
                case "Hallway3":
                    Debug.Log("Player has entered final hallway"); // will trigger 3rd and final* cs and transition to another scene
                    // inform player controller that player is in hallway
                    enteredHallway = true;
                    other.gameObject.SetActive(false);
                    break;
                default:
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        Debug.Log("Exit");
    }
}
