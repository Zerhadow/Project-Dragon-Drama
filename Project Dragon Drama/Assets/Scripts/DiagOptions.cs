using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiagOptions : MonoBehaviour
{
    public TMP_Text button1Text, button2Text, button3Text;
    public string optionChosen;
    public bool ifPressed = false;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Option1() {
        optionChosen = button1Text.text;
        ifPressed = true;
    }

    public void Option2() {
        optionChosen = button2Text.text;
        ifPressed = true;
    }

    public void Option3() {
        optionChosen = button3Text.text;
        ifPressed = true;
    }

    public void SetOptions(string option1, string option2, string option3) {
        button1Text.text = option1;
        button2Text.text = option2;
        button3Text.text = option3;
    }
}
