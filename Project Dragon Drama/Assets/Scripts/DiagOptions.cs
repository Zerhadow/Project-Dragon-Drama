using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiagOptions : MonoBehaviour
{
    public TMP_Text button1Text, button2Text, button3Text;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Option1() {
        Debug.Log("Option 1 says" + button1Text.text);

        //have player say this text
    }

    public void Option2() {
        Debug.Log("Option 2");
    }

    public void Option3() {
        Debug.Log("Option 3");  
    }
}
