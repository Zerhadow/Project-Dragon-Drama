using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public MoveDragon dragonMovement;

    public void SetMovemovent(bool b) {
        dragonMovement.canMove = b;
    }
}
