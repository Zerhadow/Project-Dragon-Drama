using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaColliderCheck : MonoBehaviour
{
    public CharacterControllerBase characterController;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter (Collider other) {
        if (other.gameObject.tag == "Player") {
            Debug.Log("Player is in the area");
            characterController.gossipSearch = false;
            characterController.setEndofDialogue(false);
        }
    }
}
