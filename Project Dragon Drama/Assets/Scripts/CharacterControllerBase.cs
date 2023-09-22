using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerState
{
    Menu, Moving, NPCTalk, Dialogue
}
public class CharacterControllerBase : MonoBehaviour
{
    [Header("Required Objects")]
    [SerializeField] GameObject _playerObject;
    /*Enable once implemented*/
    // [SerializeField] GameObject _cutscenseController;

    [Header("Movements Settings")]
    [SerializeField] float _moveSpeed = 5f;

    private Rigidbody _player;
    float moveAmountVertical = 0f;
    float moveAmountHorizontal = 0f;

    public GameObject _adjacentNPC = null;

    public PlayerState _state;
    private PlayerState _prevState;

    private void Awake()
    {
        _player = _playerObject.GetComponent<Rigidbody>();
        _state = PlayerState.Menu;
    }

    private void Update()
    {
        /* --- For Test Only --- */
        if (Input.GetKeyDown(KeyCode.U))
            _state = PlayerState.Menu;
        else if (Input.GetKeyDown(KeyCode.I))
            _state = PlayerState.Moving;
        else if (Input.GetKeyDown(KeyCode.O))
            _state = PlayerState.NPCTalk;
        else if (Input.GetKeyDown(KeyCode.P))
            _state = PlayerState.Dialogue;
        /* --- For Test Only --- */

        switch (_state)
        {
            case PlayerState.Menu: //Game Paused
                {
                    //Return to game or return to main menu options
                    stopMoving();

                    if (Input.GetKeyDown(KeyCode.Escape)) //Return to previous state
                    {
                        _state = _prevState;
                    }

                    /*Debug for state change*/
                    DebugColorUpdate(_playerObject, Color.red);
                    Debug.Log("Menu State");
                }
                break;
            case PlayerState.Moving: //Player walking around
                {
                    //Go to NPCTalk, Dialogue, Menu
                    MovementInput();

                    if (Input.GetKeyDown(KeyCode.Escape)) //GoTo Pause
                    {
                        _prevState = _state;
                        _state = PlayerState.Menu;
                    }
                    else if ((Input.GetKeyDown(KeyCode.E)) && (_adjacentNPC != null)) //Talk to NPC, GoTo NPCTalk
                    {
                        // Open dialogue popup tied to adjacentNPC

                        /*For Testing. Disable once implemented*/
                        DebugColorUpdate(_adjacentNPC, Color.green);
                        Debug.Log("Player talking to " + _adjacentNPC.name);

                        _state = PlayerState.NPCTalk;
                    }

                    /*Debug for state change*/
                    DebugColorUpdate(_playerObject, Color.blue);
                    Debug.Log("Moving State");
                }
                break;
            case PlayerState.NPCTalk: //NPC popup dialogue
                {
                    //No Movement, Click to progress or dismiss. Dismiss goes back to Moving
                    stopMoving();

                    if(Input.GetKeyDown(KeyCode.Escape)) //GoTo Pause
                    {
                        _prevState = _state;
                        _state = PlayerState.Menu;
                    }
                    else if (Input.GetKeyDown(KeyCode.E)) //Dismiss popup text, GoTo Moving
                    {
                        // Close dialogue popup

                        /*For Testing. Disable once implemented*/
                        DebugColorUpdate(_adjacentNPC, Color.magenta);
                        Debug.Log(_adjacentNPC.name + " has stopped talking");

                        _state = PlayerState.Moving;
                    }

                    /*Debug for state change*/
                    DebugColorUpdate(_playerObject, Color.yellow);
                    Debug.Log("NPCTalk State");
                }
                break;
            case PlayerState.Dialogue: //Visual novel cutscene dialoue
                {
                    //Hand off to DialogueController for cutscene. No Movement, Click to progress (speech choice within dialogue controller?). Exits to Moving.
                    stopMoving();

                    if (Input.GetKeyDown(KeyCode.Escape)) //GoTo Pause
                    {
                        _prevState = _state;
                        _state = PlayerState.Menu;
                    }

                    /*Debug for state change*/
                    DebugColorUpdate(_playerObject, Color.green);
                    Debug.Log("Dialogue State");
                }
                break;
            default:
                break;
        }
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    //Translate input for movement (must be separate from Move method due to FixedUpdate)
    private void MovementInput()
    {
        moveAmountVertical = Input.GetAxisRaw("Vertical") * _moveSpeed;
        moveAmountHorizontal = Input.GetAxisRaw("Horizontal") * _moveSpeed;
    }

    //Moves player based on player input (must be in FixedUpdate therefore is always called)
    private void MovePlayer()
    { 
        _player.velocity = new Vector3(moveAmountVertical, 0, -moveAmountHorizontal);
    }

    //Halts player movement
    private void stopMoving()
    {
        moveAmountVertical = 0f;
        moveAmountHorizontal = 0f;
    }

    //Setter for NPCController
    public void setAdjacentNPC(GameObject adjacent)
    {
        _adjacentNPC = adjacent;
    }

    //Visuals for testing
    private void DebugColorUpdate(GameObject gameObject, Color color)
    {
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", color);
    }
}
