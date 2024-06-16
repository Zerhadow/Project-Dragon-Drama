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

    #region 
    [Header("Persia Emotions")]
    public Sprite persia_neutral;
    #endregion

    #region 
    [Header("Jassica Emotions")]
    public Sprite jass_neutral;
    #endregion

    #region 
    [Header("Natalie Emotions")]
    public Sprite nat_neutral;
    #endregion

    #region 
    [Header("Ken Emotions")]
    public Sprite ken_neutral;
    #endregion

    #region 
    [Header("Silhouettes")]
    public Sprite s1;
    public Sprite s2;
    public Sprite s3;
    public Sprite s4;
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
                currImg = s_neutral;
                break;
            case "Persia":
                currImg = persia_neutral;
                break;
            case "Jassica":
                currImg = jass_neutral;
                break;
            case "Natalie":
                currImg = nat_neutral;
                break;
            case "Ken":
                currImg = ken_neutral;
                break;
            case "HomeroomTeacher":
                currImg = s2;
                break;
            default:
                currImg = s3;
                break;
        }

        currPortraitImg.sprite = currImg;
    }
}
