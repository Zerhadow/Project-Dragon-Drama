using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private UIController _ui;
    [SerializeField] private AudioController _audioController;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private DialogueController _dialogueController;
    [SerializeField] private GameTimeController _gameTimeController;
    public GameFSM _stateMachine;

    public UIController UI => _ui;
    public AudioController audioController => _audioController;
    public PlayerController playerController => _playerController;
    public DialogueController dialogueController => _dialogueController;
    public GameTimeController gameTimeController => _gameTimeController;

    private void Awake() {
        _stateMachine = GetComponent<GameFSM>();
    }

    public void ChangeStates(string str) {
        switch (str)
        {
            case "Explore":
                _stateMachine.ChangeState(_stateMachine.PlayState);
                break;
            case "Dialogue":
                _stateMachine.ChangeState(_stateMachine.DialogueState);
                break;
            case "Setup":
                _stateMachine.ChangeState(_stateMachine.SetupState);
                break;
            default:
                break;
        }
    }

    public void ChangeToPreviousState() {
        _stateMachine.ChangeStateToPrevious();
    }

    public void NextScene() {
        // Get the current active scene's build index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the next scene in the build order
        SceneManager.LoadScene(currentSceneIndex++);
    }

    public void EveningCall() {
        // Calling someone
        // Build 1 will just choose Sam
        
        NodeList nl = dialogueController.eveningCharBooks[0];
        dialogueController.SetCurrentNodeList(nl);
        ChangeStates("Dialogue");
    }
}
