using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortraitController : MonoBehaviour
{
    public Sprite currImg;
    public GameObject currPortraitObj;
    public Image currPortraitImg;
    #region 
    [Header("Bailey Emotions")]
    public Sprite b_neutral;
    #endregion

    #region 
    [Header("Sam Emotions")]
    public Sprite s_neutral;
    #endregion

    public Sprite mg1PFP, mg2PFP, mg3PFP, kenPFP; // UI Images for each character

    #region 
    [Header("Sam Silhouettes")]
    public Sprite s1, s2, s3, s4;
    #endregion

    public void ResetPortraits() {
        currImg = null;
        currPortraitObj.SetActive(true);
    }
    
    public void SetPortrait(string name, int emotion) {
        // Debug.Log("Name: " + name);
        switch(name) {
            case "Bailey":
                currImg = b_neutral;
                break;
            case "Sam":
                // b_neutral.SetActive(true);
                currImg = s1;
                break;
            case "Persia":
                // b_neutral.SetActive(true);
                break;
            case "Jassica":
                // b_neutral.SetActive(true);
                break;
            case "Natalie":
                break;
            case "HomeroomTeacher":
                currImg = s2;
                break;
            default:
                break;
        }

        currPortraitImg.sprite = currImg;
    }
}
