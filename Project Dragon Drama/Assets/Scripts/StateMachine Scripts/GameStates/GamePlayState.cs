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
        
        // Allow player movement
        // _controller.playerController.LockMovement();
    }

    public override void Update()
    {
        base.Update();

        // if player presses pause key, go to pause state
        // Hard input for now
        if(Input.GetKeyDown(KeyCode.Escape)) { _stateMachine.ChangeState(_stateMachine.PauseState); }

        // Check for player interaction with NPC
        // if interact if NPC, then
        // _stateMachine.ChangeState(_stateMachine.PauseState);
    }

    public override void Exit() {
        base.Exit();

        // Deactivate UI Elems

    }
}
