using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagController : MonoBehaviour
{
    public bool test = false;
    public bool introQuestStart = false;

    public bool GetFlag(string str) {
        switch (str) {
            case "Test":
                return test;
            case "Intro Quest Start":
                return introQuestStart;
            default:
                return false;
        }
    }
}
