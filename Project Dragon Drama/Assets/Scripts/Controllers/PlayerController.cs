using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameController gameController;
    public MoveDragon dragonMovement;
    public AreaController playerAreaController;

    public void SetMovemovent(bool b) {
        dragonMovement.canMove = b;
    }

    private void Awake() {
        gameController = GetComponentInParent<GameController>();
    }

    private void Update() {
        if(playerAreaController.enteredHallway) {
            // check time of day
            var timeInfo = gameController.gameTimeController.GetCurrentTimeInfo();
            // Debug.Log("Current Week: " + timeInfo.week);
            // Debug.Log("Current Day of Week: " + timeInfo.dayOfWeek);
            // Debug.Log("Current Time of Day: " + timeInfo.timeOfDay);

            bool timeCheck = gameController.gameTimeController.GetCheckTimeInfo(timeInfo);

            if(timeCheck) {
                // go to next composite node
                gameController.ChangeStates("Dialogue");
            }

            playerAreaController.enteredHallway = false;
        }
    }
}
