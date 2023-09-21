using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerState
{
    Menu, Moving, NPCTalk, Dialogue
}
public class CharacterControllerBase : MonoBehaviour
{
    [Header("Game Objects")]
    [SerializeField] GameObject _playerObject;
    /*Enable once implemented*/
    // [SerializeField] GameObject _cutscenseController;

    [Header("Movements Settings")]
    [SerializeField] float _moveSpeed = 5f;

    private Rigidbody _player;
    float moveAmountVertical = 0f;
    float moveAmountHorizontal = 0f;

    public PlayerState _state;

    private void Awake()
    {
        _player = _playerObject.GetComponent<Rigidbody>();
        _state = PlayerState.Menu;
    }

    private void Update()
    {
        /* For Test Only */
        if (Input.GetKeyDown(KeyCode.U))
            _state = PlayerState.Menu;
        else if (Input.GetKeyDown(KeyCode.I))
            _state = PlayerState.Moving;
        else if (Input.GetKeyDown(KeyCode.O))
            _state = PlayerState.NPCTalk;
        else if (Input.GetKeyDown(KeyCode.P))
            _state = PlayerState.Dialogue;

        switch (_state)
        {
            case PlayerState.Menu: //Game Paused
                //Return to game or return to main menu options
                stopMoving();
                _playerObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red); //for test visual
                Debug.Log("Menu State");
                break;
            case PlayerState.Moving:
                MovementInput();
                //Go to NPCTalk, Dialogue, Menu
                _playerObject.GetComponent<Renderer>().material.SetColor("_Color", Color.blue); //for test visual
                Debug.Log("Moving State");
                break;
            case PlayerState.NPCTalk:
                //No Movement, Click to progress or dismiss. Dismiss goes back to Moving
                stopMoving();
                _playerObject.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow); //for test visual
                Debug.Log("NPCTalk State");
                break;
            case PlayerState.Dialogue:
                //Hand off to DialogueController for cutscene. No Movement, Click to progress (speech choice within dialogue controller?). Exits to Moving.
                stopMoving();
                _playerObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green); //for test visual
                Debug.Log("Dialogue State");
                break;
            default:
                break;
        }
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovementInput()
    {
        moveAmountVertical = Input.GetAxisRaw("Vertical") * _moveSpeed;
        moveAmountHorizontal = Input.GetAxisRaw("Horizontal") * _moveSpeed;
    }

    private void stopMoving()
    {
        moveAmountVertical = 0f;
        moveAmountHorizontal = 0f;
    }

    //Moves player based on player input
    private void MovePlayer()
    { 
        _player.velocity = new Vector3(moveAmountVertical, 0, -moveAmountHorizontal);
    }
}
