using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveDragon : MonoBehaviour
{
    public Transform dragonTransform; // for the dragon GameObject
    Vector2 moveDirection = Vector2.zero;
    public float speed = 3f;
    public PlayerControls playerControls;
    private InputAction move;
    public bool canMove = true;
    public Animator baileyAnimator;

    public float minX = -5f; // minimum x-value of the plane
    public float maxX = 5f;  // maximum x-value of the plane
    public float minZ = -5f; // minimum z-value of the plane
    public float maxZ = 5f;  // maximum z-value of the plane

    private void Awake()
    {
        playerControls = new PlayerControls();
        move = playerControls.Player.Move;
        dragonTransform = transform;
        baileyAnimator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        move.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
    }

    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
        
    }

    private void FixedUpdate()
    {
        if(canMove) {
            float moveX = moveDirection.x * speed * Time.fixedDeltaTime;
            float moveZ = moveDirection.y * speed * Time.fixedDeltaTime; 

            Vector3 newPosition = dragonTransform.position + new Vector3(moveX, 0f, moveZ);
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
            newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);

            dragonTransform.position = newPosition;
        }
    }
}
