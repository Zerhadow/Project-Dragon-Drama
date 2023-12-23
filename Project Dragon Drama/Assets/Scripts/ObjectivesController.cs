using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectivesController : MonoBehaviour
{
    [SerializeField] GameObject objectives;
    [SerializeField] TextMeshProUGUI _txt;

    // Turn on objectives box
    public void EnableObjectives()
    {
        objectives.SetActive(true);
    }

    // Turn off objectives box
    public void DisableObjectives()
    {
        objectives.SetActive(false);
    }

    // Set objectives text based on chapter & key gossip
    public void SetObjectiveText(bool cutsceneReady, int chapter)
    {
        if (cutsceneReady)
        {
            switch(chapter)
            {
                case 0:
                    _txt.SetText("You Shouldn't See This");
                    break;
                case 1:
                    _txt.SetText("Talk to People");
                    break;
                case 2:
                    _txt.SetText("Return to Sam");
                    break;
                case 3:
                    _txt.SetText("Speak with Sam");
                    break;
                case 4:
                    _txt.SetText("Return to Sam");
                    break;
                case 5:
                    _txt.SetText("Check on Persia");
                    break;
                case 6:
                    _txt.SetText("Speak with Sam");
                    break;
                case 7:
                    _txt.SetText("Speak with Nataly");
                    break;
                case 8:
                    _txt.SetText("Return to Sam");
                    break;
                case 9:
                    _txt.SetText("Speak with Ken");
                    break;
                case 10:
                    _txt.SetText("Speak with Sam");
                    break;
                case 11:
                    _txt.SetText("Speak with Nataly");
                    break;
                case 12:
                    _txt.SetText("Check on Ken");
                    break;
            }
        }
        else
        {
            _txt.SetText("Talk to People");
        }
    }
}
