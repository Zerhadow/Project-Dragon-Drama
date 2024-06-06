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
        
        // Allow player to move char
        // _controller.playerController.Movement();s
        _controller.playerController.SetMovemovent(true);

    }

    public override void Update()
    {
        base.Update();

        // if player presses pause key, go to pause state
        // Hard input for now
        if(Input.GetKeyDown(KeyCode.Escape)) { _stateMachine.ChangeState(_stateMachine.PauseState); }
        if(Input.GetKeyDown(KeyCode.E)) {
            // check what player is interacting with
            NPCController npc = _controller.playerController.npc;

            if(npc != null) { // they are currently in range to talk to npc
                _controller.playerController.NPCInteract();
            }

            // they are currently in range to interact with item
        }
        
    }

    public override void Exit() {
        base.Exit();

        // Deactivate UI Elems
        _controller.UI.DialogueObj.SetActive(false);

        // Return movement to char
        // _controller.playerController.UnlockMovement();
        _controller.playerController.SetMovemovent(false);
    }
}
