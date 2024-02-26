using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public GamePlayState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

        public override void Enter() {
        base.Enter();

        Debug.Log("STATE: Game Play State");

        // Activate UI Elems
        _controller.UI.DialogueObj.SetActive(true);
        
        // Don't allow player to move char
        // _controller.playerController.LockMovement();
    }

    public override void Update()
    {
        base.Update();

        // if player presses pause key, go to pause state
        // Hard input for now
        if(Input.GetKeyDown(KeyCode.Escape)) { _stateMachine.ChangeState(_stateMachine.PauseState); }
    }

    public override void Exit() {
        base.Exit();

        // Deactivate UI Elems
        _controller.UI.DialogueObj.SetActive(false);

        // Return movement to char
        // _controller.playerController.UnlockMovement();
    }
}
