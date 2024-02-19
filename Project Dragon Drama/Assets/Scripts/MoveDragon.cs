using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


/*
 * questions:
 * 1. fly up/down as well?
 * 2. backwards movement (turn body)
 * 3. camera???
 */


public class MoveDragon : MonoBehaviour
{
    public float speed = 3f;
    public float minY = 1f; // can change
    public float maxY = 5f; // can change
    public float minX = -5f; // minimum x-value of the plane
    public float maxX = 5f;  // maximum x-value of the plane
    public float minZ = -5f; // minimum z-value of the plane
    public float maxZ = 5f;  // maximum z-value of the plane

    void Update()
    {
        Vector2 moveInput = GetInput();
        Move(moveInput);
    }

    Vector2 GetInput()
    {
        Vector2 moveInput = Vector2.zero;
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        return moveInput;
    }

    void Move(Vector2 direction)
    {
        Vector3 newPosition = transform.position + new Vector3(direction.x, 0f, direction.y) * speed * Time.deltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
        transform.position = newPosition;
    }
}
