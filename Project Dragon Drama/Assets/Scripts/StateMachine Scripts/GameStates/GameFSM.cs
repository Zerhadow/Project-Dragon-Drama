using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameController))]
public class GameFSM : StateMachineMB
{
    private GameController _controller;

    // state instances
    public GameSetupState SetupState { get; private set; }
    public GamePauseState PauseState { get; private set; }
    public GameDialogueState DialogueState { get; private set; }
    
    private void Awake() {
        _controller = GetComponent<GameController>();
        
        // create states
        SetupState = new GameSetupState(this, _controller);
        PauseState = new GamePauseState(this, _controller);
        DialogueState = new GameDialogueState(this, _controller);
    }

    private void Start() {
        ChangeState(SetupState);
    }
}
