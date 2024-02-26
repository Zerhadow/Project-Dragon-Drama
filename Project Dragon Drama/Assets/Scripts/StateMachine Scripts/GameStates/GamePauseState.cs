using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public GamePauseState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

        public override void Enter() {
        base.Enter();

        Debug.Log("STATE: Game Paused");

        // Activate UI Elems
        _controller.UI.pauseMenuObj.SetActive(true);

        // Don't allow player to move char
        // _controller.playerController.LockMovement();
    }

    public override void Update()
    {
        base.Update();

        // Watch for key press to un pause
        if(Input.GetKeyDown(KeyCode.Escape)) { _stateMachine.ChangeState(_stateMachine.SetupState); }
    }

    public override void Exit() {
        base.Exit();
        
        // Deactivate UI Elems
        _controller.UI.pauseMenuObj.SetActive(false);

        // Return movement to char
        // _controller.playerController.UnlockMovement();
    }
}
