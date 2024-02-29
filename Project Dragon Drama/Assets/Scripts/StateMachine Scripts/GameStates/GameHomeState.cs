using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHomeState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public GameHomeState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter() {
        base.Enter();

        Debug.Log("STATE: Game Home State");

        // Activate UI Elems
        
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

        // Return movement to char
        // _controller.playerController.UnlockMovement();
    }
}
