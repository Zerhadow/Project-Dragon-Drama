using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleStairs_Tele : MonoBehaviour
{
    [SerializeField] Transform destination;
    [SerializeField] GameObject secondFloor;

    [Header ("True = Going Up || False = Going Down")]
    [SerializeField] bool direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Player entered stairs");

            other.transform.position = destination.position;
            //other.transform.rotation = destination.rotation;

            if (direction)
            {
                secondFloor.GetComponent<MeshRenderer>().enabled = true;
            }
            else
            {
                secondFloor.GetComponent<MeshRenderer>().enabled = false;
            }
            
        }
    }
}
