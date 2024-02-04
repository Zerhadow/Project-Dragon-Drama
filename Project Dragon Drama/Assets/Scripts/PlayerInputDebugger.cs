using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    private void Awake()
    {
        // Check if the collider component is attached
        Collider collider = GetComponent<Collider>();
        if (collider == null)
        {
            Debug.LogError("Collider component is missing on ScreenCollider GameObject.");
        }

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0 -> left mouse button
        {
            Vector3 clickPosition = Input.mousePosition;
            Debug.Log("Player clicked at: " + clickPosition);
        }
    }
}
