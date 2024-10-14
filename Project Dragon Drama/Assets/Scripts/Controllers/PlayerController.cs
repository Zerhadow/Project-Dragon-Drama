using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameController gameController;
    public MoveDragon dragonMovement;
    public AreaController playerAreaController;
    public NPCController npc; // npc they are in range or talking too
    public FlagController flagController;

    public void SetMovemovent(bool b) {
        dragonMovement.canMove = b;
    }

    private void Awake() {
        gameController = GetComponentInParent<GameController>();
        flagController = GetComponentInChildren<FlagController>();
    }

    private void Update() {
        if(playerAreaController.enteredHallway) {
            // check time of day
            var timeInfo = gameController.gameTimeController.GetCurrentTimeInfo();
            Debug.Log("Current Week: " + timeInfo.week);
            Debug.Log("Current Day of Week: " + timeInfo.dayOfWeek);
            Debug.Log("Current Time of Day: " + timeInfo.timeOfDay);

            bool timeCheck = gameController.gameTimeController.GetCheckTimeInfo(timeInfo);

            if(timeCheck) {
                // go to next composite node
                gameController.ChangeStates("Dialogue");
            }

            playerAreaController.enteredHallway = false;
        }
    }

    public void NPCInteract() {
        Debug.Log("Talking to NPC");

        // get NPC info

        // set composite node for dialogue controller
        gameController.dialogueController.SetCurrentNodeList(npc.dialogueNodeLists[npc.nodeIdx]);
        npc.talkedToToday = true;
        npc.pressETextBox.SetActive(false);

        // go to dialogue controller
        gameController.ChangeStates("Dialogue");
    }

    public void ItemInteract() {
        Debug.Log("Interacting with item");
    }
}
