using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueDictionaries : MonoBehaviour {
    public Player player = new Player();
    public Meangirl1 meangirl1 = new Meangirl1();
    public Meangirl2 meangirl2 = new Meangirl2();
    public Meangirl3 meangirl3 = new Meangirl3();
}

public class Player {
    int index;
    string text;
    public Dictionary<int, string> playerDiagBank = new Dictionary<int, string>();

    public void fillBank() {
        # region Chapter 1
        playerDiagBank.Add(0, "Hello, I am the player.");
        playerDiagBank.Add(1, "I am a player.");
        playerDiagBank.Add(2, "I am a player.");
        # endregion
    }
}

public class Meangirl1 {
    int index;
    string text;
    public Dictionary<int, string> meangirl1DiagBank = new Dictionary<int, string>();

    public void fillBank() {
        # region Chapter 1
        meangirl1DiagBank.Add(0, "I am Regina George.");
        meangirl1DiagBank.Add(1, "I am a player.");
        meangirl1DiagBank.Add(2, "I am a player.");
        # endregion
    }
}

public class Meangirl2 {
    int index;
    string text;
    public Dictionary<int, string> meangirl2DiagBank = new Dictionary<int, string>();

    public void fillBank() {
        # region Chapter 1
        meangirl2DiagBank.Add(0, "Hello, I am the player.");
        meangirl2DiagBank.Add(1, "I am a player.");
        meangirl2DiagBank.Add(2, "I am a player.");
        # endregion
    }
}

public class Meangirl3 {
    int index;
    string text;
    public Dictionary<int, string> meangirl3DiagBank = new Dictionary<int, string>();

    public void fillBank() {
        # region Chapter 1
        meangirl3DiagBank.Add(0, "Hello, I am the player.");
        meangirl3DiagBank.Add(1, "I am a player.");
        meangirl3DiagBank.Add(2, "I am a player.");
        # endregion
    }
}