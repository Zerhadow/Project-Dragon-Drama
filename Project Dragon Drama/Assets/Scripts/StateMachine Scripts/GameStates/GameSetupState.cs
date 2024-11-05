using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSetupState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;
    private bool eveningScene;

    public GameSetupState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter() {
        base.Enter();

        Debug.Log("STATE: Game Setup");

        // Disables everything on the canvas
        // Iterate through all child GameObjects
        foreach (Transform child in _controller.UI.canvas.transform)
        {
            // Set each child GameObject to inactive
            child.gameObject.SetActive(false);
        }

        if(SceneManager.GetActiveScene().name == "night_b1") {
            eveningScene = true;
            _controller.UI.eveningObj.SetActive(true);
        } else { // you are in explore scene
            eveningScene = false;
            _controller.playerController.SetMovemovent(false);
        }

        // possible fade in; use couroutine
    }

    public override void Update()
    {
        base.Update();

        if(!eveningScene) {
            _stateMachine.ChangeState(_stateMachine.DialogueState); // runs on 1st tick
        }

        // Debug Purposes: Will do key inputs to switch
        if(Input.GetKeyDown(KeyCode.Escape)) { _stateMachine.ChangeState(_stateMachine.PauseState); }
        if(Input.GetKeyDown(KeyCode.D)) { _stateMachine.ChangeState(_stateMachine.DialogueState); }
        if(Input.GetKeyDown(KeyCode.P)) { _stateMachine.ChangeState(_stateMachine.PlayState); }
    }

    public override void Exit() {
        base.Exit();
    }
}
