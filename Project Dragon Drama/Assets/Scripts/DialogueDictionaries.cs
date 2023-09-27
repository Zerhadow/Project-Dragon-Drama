using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueDictionaries : MonoBehaviour {
    public Player player = new Player();
    public Meangirl1 meangirl1 = new Meangirl1();
    public Meangirl2 meangirl2 = new Meangirl2();
    public Meangirl3 meangirl3 = new Meangirl3();
    public Friend friend = new Friend();
    public DialogueOptionsText diagOptions = new DialogueOptionsText();
}

public class Player {
    int index;
    string text;
    public Dictionary<int, string> playerDiagBank = new Dictionary<int, string>();

    public void fillBank() {
        # region Chapter 1
        playerDiagBank.Add(0, "What is?");
        playerDiagBank.Add(1, "…And?");
        playerDiagBank.Add(2, "I am a player.");
        # endregion
    }
}

public class Friend {
    int index;
    string text;
    public Dictionary<int, string> friendDiagBank = new Dictionary<int, string>();

    public void fillBank() {
        # region Chapter 1
        friendDiagBank.Add(0, "That's crazy...");
        friendDiagBank.Add(1, "You’ve been completely focused, the entire class.");
        friendDiagBank.Add(2, "You’re weird.");
        friendDiagBank.Add(3, "Name’s Sam by the way.");
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
        meangirl1DiagBank.Add(1, "Well that's a weird thing to say.");
        meangirl1DiagBank.Add(2, "You’re weird.");
        # endregion
    }
}

public class Meangirl2 {
    int index;
    string text;
    public Dictionary<int, string> meangirl2DiagBank = new Dictionary<int, string>();

    public void fillBank() {
        # region Chapter 1
        meangirl2DiagBank.Add(0, "Hello, I am ");
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

public class DialogueOptionsText {
    int index;
    string text;
    public Dictionary<int, string> dialogueOptionsBank1 = new Dictionary<int, string>();

    public void fillBank1() {
        dialogueOptionsBank1.Add(0, "Buy apple");
        dialogueOptionsBank1.Add(1, "Buy orange");
        dialogueOptionsBank1.Add(2, "Buy banana");
    }
}