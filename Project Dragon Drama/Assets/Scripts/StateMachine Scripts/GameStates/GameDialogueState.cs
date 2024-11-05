using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDialogueState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;
    private bool eveningScene;

    public GameDialogueState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter() {
        base.Enter();

        Debug.Log("STATE: Game Dialogue State");

        // Activate UI Elems
        _controller.UI.DialogueObj.SetActive(true);

        if(SceneManager.GetActiveScene().name == "night_b1") {
            eveningScene = true;
            _controller.UI.eveningObj.SetActive(false);
        } else { // you are in explore scene
            eveningScene = false;
            _controller.playerController.SetMovemovent(false); // dont allow player to move
        }

        _controller.dialogueController.StartDialogue();

        _controller.dialogueController.portraitController.ResetPortraits();
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
        _controller.playerController.SetMovemovent(true);
    }
}
