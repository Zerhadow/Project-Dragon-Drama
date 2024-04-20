using UnityEngine;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{
    public GameObject player;
    public GameObject interactionMessage;

    private bool canInteract = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("On Trigger Enter");
        canInteract = true;
        interactionMessage.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("On Trigger Exit");
        canInteract = false;
        interactionMessage.SetActive(false);
        
    }

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Interacting with sphere");
        }
    }
}