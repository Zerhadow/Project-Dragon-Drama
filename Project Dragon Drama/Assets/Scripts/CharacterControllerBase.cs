using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum PlayerState
{
    Menu, Moving, NPCTalk, Dialogue
}
public class CharacterControllerBase : MonoBehaviour
{
    //Singleton
    public static CharacterControllerBase Instance;

    /*
    [Header("Required Objects")]
    [SerializeField] GameObject _playerObject;
    [SerializeField] GameObject _cutscenseController;
    public GameObject pressETextBox;
    public GameObject dialogueTextBox;
    public GameObject continueTextBox;
    public CutSceneController cutSceneController;
    */

    private GameObject _playerObj;
    private Rigidbody _playerRb;
    private GameObject pressETextBox;
    public GameObject dialogueTextBox;
    private GameObject continueTextBox;
    private CutSceneController cutSceneController;

    [Header("Movements Settings")]
    [SerializeField] float _moveSpeed = 5f;

    float _moveAmountVertical = 0f;
    float _moveAmountHorizontal = 0f;
    private InventoryController _inventory;

    public GameObject _adjacentNPC = null;

    public PlayerState _state;
    private PlayerState _prevState;

    public bool endofDialogue = false;
    public bool gossipSearch = false;
    public bool NPCTalking = false;

    public NPCControllerBase npcObj;

    private int playerPoints = 1;
    public int pageIdx = 0;
    // set an if statement to know if its the last chapter to check player points

    private void Awake()
    {
        //Singleton check: if there exists and instance and it isn't this, delete this.
        if ((Instance != null) && (Instance != this))
        {
            Destroy(this);
            Debug.Log("CharController: There can be only one");
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            Debug.Log("CharController: I am the one");
        }

        //Find and set object references
        _playerObj = GameObject.Find("Player");
        _playerRb = _playerObj.GetComponent<Rigidbody>();
        _inventory = this.GetComponent<InventoryController>();
        pressETextBox = GameObject.Find("PressE");
        dialogueTextBox = GameObject.Find("DialogBar");
        continueTextBox = GameObject.Find("Continue");
        cutSceneController = GameObject.Find("Canvas").GetComponent<CutSceneController>();
        dialogueTextBox.SetActive(false);
        continueTextBox.SetActive(false);
        // Debug.Log("CharController: " + pressETextBox.name.ToString() + " is linked");
        // Debug.Log("CharController: " + dialogueTextBox.name.ToString() + " is linked");
        // Debug.Log("CharController: " + continueTextBox.name.ToString() + " is linked");
        // Debug.Log("CharController: " + cutSceneController.name.ToString() + " is linked");

        //initial scene setup
        _state = PlayerState.Moving;
        _inventory.Clear();
    }

    private void  Start() {
        pressETextBox.SetActive(false);
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
        else if (Input.GetKeyDown(KeyCode.L))
            SceneManager.LoadScene("SchoolLevelTest", LoadSceneMode.Single); //go to SchoolLevelTest
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
                    DebugColorUpdate(_playerObj, Color.red);
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
                        if(!gossipSearch && _adjacentNPC.name == "Sam") { //start cutscene
                            // Open dialogue popup tied to adjacentNPC
                            if(_inventory.GetSize() > 0) {
                                playerPoints++;
                            } else {
                                playerPoints--;
                            }

                            Debug.Log("Points: " + playerPoints);

                            cutSceneController.StartCutscene();

                            _state = PlayerState.Dialogue;
                        } else if(gossipSearch && _adjacentNPC.name == "Key") {
                            Debug.Log("Found Key");
                        } 
                        
                        else {
                            npcObj = _adjacentNPC.transform.Find("Talk Range").gameObject.GetComponent<NPCControllerBase>();
                            // Open dialogue popup tied to adjacentNPC;
                            cutSceneController.NPCtalk(npcObj);
                            _state = PlayerState.NPCTalk;
                        }

                        //Check if NPC gives key gossip and add to inventory if true
                        if(_adjacentNPC.transform.Find("Talk Range").gameObject.GetComponent<NPCControllerBase>().GiveKeyGossip())
                        {
                            string gossipKey = _adjacentNPC.name.ToString();
                            _inventory.AddItem(gossipKey);
                        }

                        /*For Testing. Disable once implemented*/
                        DebugColorUpdate(_adjacentNPC, Color.green);
                        // Debug.Log("Player talking to " + _adjacentNPC.name);
                    }

                    /*Debug for state change*/
                    DebugColorUpdate(_playerObj, Color.blue);
                    // Debug.Log("Moving State");
                }
                break;
            case PlayerState.NPCTalk: //NPC popup dialogue
                {                    
                    NPCTalking = true;
                    //No Movement, Click to progress or dismiss. Dismiss goes back to Moving
                    stopMoving();

                    if(Input.GetKeyDown(KeyCode.Escape)) //GoTo Pause
                    {
                        _prevState = _state;
                        _state = PlayerState.Menu;
                    }
                    else if (Input.GetKeyDown(KeyCode.E) && NPCTalking) //Dismiss popup text, GoTo Moving
                    {
                        // Close dialogue popup
                        dialogueTextBox.SetActive(false);
                        continueTextBox.SetActive(false);

                        /*For Testing. Disable once implemented*/
                        DebugColorUpdate(_adjacentNPC, Color.magenta);
                        // Debug.Log(_adjacentNPC.name + " has stopped talking");

                        _state = PlayerState.Moving;
                    }

                    /*Debug for state change*/
                    DebugColorUpdate(_playerObj, Color.yellow);
                    // Debug.Log("NPCTalk State");
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
                    else if (Input.GetKeyDown(KeyCode.E) && endofDialogue) //Dismiss popup text, GoTo Moving
                    {
                        // Close dialogue popup
                        dialogueTextBox.SetActive(false);
                        continueTextBox.SetActive(false);

                        /*For Testing. Disable once implemented*/
                        DebugColorUpdate(_adjacentNPC, Color.magenta);
                        // Debug.Log(_adjacentNPC.name + " has stopped talking");

                        _state = PlayerState.Moving;
                    }

                    /*Debug for state change*/
                    DebugColorUpdate(_playerObj, Color.green);
                    // Debug.Log("Dialogue State");
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
        _moveAmountVertical = Input.GetAxisRaw("Vertical") * _moveSpeed;
        _moveAmountHorizontal = Input.GetAxisRaw("Horizontal") * _moveSpeed;
    }

    //Moves player based on player input (must be in FixedUpdate therefore is always called)
    private void MovePlayer()
    {
        Vector3 expectedVelocity = new Vector3(_moveAmountVertical, 0, -_moveAmountHorizontal);
        _playerRb.AddForce(expectedVelocity - _playerRb.velocity, ForceMode.VelocityChange);
    }

    //Halts player movement
    private void stopMoving()
    {
        _moveAmountVertical = 0f;
        _moveAmountHorizontal = 0f;
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
