using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private UIController _ui;
    [SerializeField] private AudioController _audioController;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private DialogueController _dialogueController;
    public GameFSM _stateMachine;

    public UIController UI => _ui;
    public AudioController audioController => _audioController;
    public PlayerController playerController => _playerController;
    public DialogueController dialogueController => _dialogueController;

    private void Awake() {
        _stateMachine = GetComponent<GameFSM>();
    }
}
