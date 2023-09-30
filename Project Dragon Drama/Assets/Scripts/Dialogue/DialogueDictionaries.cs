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

    public Narrator narrator = new Narrator();
    public Teacher teacher = new Teacher();
    public KeyStudent keyStudent = new KeyStudent();
}

public class Narrator {
    int index;

    string text;
    public Dictionary<int, string> narratorDiagBank = new Dictionary<int, string>();int idx = 0;


    public void fillBank() {
        int idx = 0;

        # region Cutscene 1
        narratorDiagBank.Add(idx++, "The teacher in the front of the classroom, going off on a long lecture");
        narratorDiagBank.Add(idx++, "She pauses from taking notes and looks around the room");
        narratorDiagBank.Add(idx++, "To her surprise there actually is one person staring at her, the girl sitting right next to her.");
        narratorDiagBank.Add(idx++, "Bailey Jumps at little when their gazes meet");
        narratorDiagBank.Add(idx++, "A dragon roars and the students get out of their seats and start to move, class is over.");
        narratorDiagBank.Add(idx++, "The two move move into the hallway");
        narratorDiagBank.Add(idx++, "Three girls are walking in the hallway. They catch Bailey's eye.");
        #endregion

        # region Cutscene 3
        narratorDiagBank.Add(idx++, "With this new found knowledge you go back to Sam.");
        narratorDiagBank.Add(idx++, "The Dragon roar is heard again and students are moving to class.");
        #endregion

        # region Cutscene 4
        narratorDiagBank.Add(idx++, "The next day, you find Sam in the Library");
        #endregion
    }
}

public class Teacher {
    int index;
    string text;
    public Dictionary<int, string> teacherDiagBank = new Dictionary<int, string>();

    public void fillBank() {
        int idx = 0;

        # region Cutscene 1

        teacherDiagBank.Add(index++, "Teacher: And here's a hint to the book we’ll be talking about! “The supreme art of war is to subdue the enemy without fighting”");

        #endregion
    }

    
}

public class Player {
    int index;
    string text;
    public Dictionary<int, string> playerDiagBank = new Dictionary<int, string>();

    public void fillBank() {
        int idx = 0;

        # region Cutscene 1
        playerDiagBank.Add(idx++, "*Today is my first day at Dragon High. And since the start of the day, I've been nothing but a nervous wreck*");
        playerDiagBank.Add(idx++, "*It feels like everyone’s always staring at me. Even if they actually aren’t.*");
        playerDiagBank.Add(idx++, "What is?");
        playerDiagBank.Add(idx++, "…And?");
        playerDiagBank.Add(idx++, "Nice to meet you.");
        playerDiagBank.Add(idx++, "It’s Bailey");
        playerDiagBank.Add(idx++, "I think I have Gold Hoarding.");
        playerDiagBank.Add(idx++, "Who are they?");
        playerDiagBank.Add(idx++, "Smaugs?");
        playerDiagBank.Add(idx++, "Then why do they get so much attention?");
        playerDiagBank.Add(idx++, "Ok then…");
        # endregion

        #region Cutscene 2
        playerDiagBank.Add(idx++, "Hi!");
        playerDiagBank.Add(idx++, "Yup! You wouldn’t happen to know anything about the Smaugs would you?");
        playerDiagBank.Add(idx++, "You’re sleeping with one of them?");
        playerDiagBank.Add(idx++, "So… blackmail");
        playerDiagBank.Add(idx++, "Wouldn’t that go against what you’re doing?");
        playerDiagBank.Add(idx++, "What?");
        #endregion

        #region Cutscene 3
        playerDiagBank.Add(idx++, "Nope. But it’s definitely one of the Smaugs.");
        #endregion

        #region Cutscene 4
        playerDiagBank.Add(idx++, "You didn’t sleep?");
        playerDiagBank.Add(idx++, "Fine. What do I do?");
        playerDiagBank.Add(idx++, "That’s it? That’s what you spent the whole night working on?");
        playerDiagBank.Add(idx++, "You wouldn’t happen to know where her stuff is would you?");
        #endregion
    }
}

public class Friend {
    int index;
    string text;
    public Dictionary<int, string> friendDiagBank = new Dictionary<int, string>();

    public void fillBank() {
        int idx = 0;

        # region Cutscene 1
        friendDiagBank.Add(idx++, "That's crazy...");
        friendDiagBank.Add(idx++, "You’ve been completely focused, the entire class.");
        friendDiagBank.Add(idx++, "You’re weird.");
        friendDiagBank.Add(idx++, "Name’s Sam by the way.");
        friendDiagBank.Add(idx++, "So you got a name Newbie?");
        friendDiagBank.Add(idx++, "Well Baily What class do you have next?");
        friendDiagBank.Add(idx++, "Oh! I know exactly where that is!");
        friendDiagBank.Add(idx++, "That one should be at the end of the hall on the left.");
        friendDiagBank.Add(idx++, "Oh! Those are the Smaugs.");
        friendDiagBank.Add(idx++, "Basically they think that they run the School, but no one really cares.");
        friendDiagBank.Add(idx++, "Because they’re the Smaugs. What else is there to know?");
        friendDiagBank.Add(idx++, "God. How much I’d love to tear them Down off of their high horse.");
        friendDiagBank.Add(idx++, "I’m sure others agree with me. If you don’t believe me, go on ahead and Chat with other people.");
        # endregion

        #region Cutscene 3
        friendDiagBank.Add(idx++, "Oh my God! Really! Do you know which one?");
        friendDiagBank.Add(idx++, "I’d bet it’s Persia, she’s always bragging about How huge her family’s hoard is.");
        friendDiagBank.Add(idx++, "We’ll talk more tomorrow, just keep that info in mind, okay?");
        #endregion

        #region Cutscene 4
        friendDiagBank.Add(idx++, "I have spent the entire night planning how to take her down.");
        friendDiagBank.Add(idx++, "No. Not really, so I’m gonna need you to take care of it for us.");
        friendDiagBank.Add(idx++, "Well, if he knew about her being broke then there has to be some kind of evidence she carries on her to prove she’s faking it.");
        friendDiagBank.Add(idx++, "No!... Kinda…");
        friendDiagBank.Add(idx++, "I spent most of the night thinking about What the thing she might have.");
        friendDiagBank.Add(idx++, "If you just go looking around her stuff I’m sure you’ll find it.");
        friendDiagBank.Add(idx++, "Nope! But you’re a social butterfly, Seeing how you got the biggest Tea this school has seen on your Very first day.");
        friendDiagBank.Add(idx++, "I’m sure you’ll figure it out. Now go, I got some snoring to do.");
        
        #endregion
    }
}

public class Meangirl1 {
    int index;
    string text;
    public Dictionary<int, string> meangirl1DiagBank = new Dictionary<int, string>();

    public void fillBank() {
        # region Custscene 2
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
        # region Cutscene 2
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
        # region Cutscene 2
        meangirl3DiagBank.Add(0, "Hello, I am the player.");
        meangirl3DiagBank.Add(1, "I am a player.");
        meangirl3DiagBank.Add(2, "I am a player.");
        # endregion
    }
}

public class KeyStudent {
    int index;
    string text;
    public Dictionary<int, string> keyStudentDiagBank = new Dictionary<int, string>();

    public void fillBank() {
        int idx = 0;

        # region Key 1
        keyStudentDiagBank.Add(idx++, "Oh hi! You’re the new one right?");
        keyStudentDiagBank.Add(idx++, "The Smaugs! Oh…");
        keyStudentDiagBank.Add(idx++, "I’ve got a little piece of info that one of them is keeping me on the hush-hush if you know what I mean.");
        keyStudentDiagBank.Add(idx++, "God no! What the hell?? One of them is paying me to not say anything.");
        keyStudentDiagBank.Add(idx++, "Pretty Much!");
        keyStudentDiagBank.Add(idx++, "You wanna know it?");
        keyStudentDiagBank.Add(idx++, "I don’t care, I’ve already got all the money I want.");
        keyStudentDiagBank.Add(idx++, "Besides, she’s broke as shit.");
        keyStudentDiagBank.Add(idx++, "Whoops…");
        keyStudentDiagBank.Add(idx++, "Let’s just leave it at that shall we.");
        
        # endregion
    }
}

public class DialogueOptionsText {
    public Dictionary<int, string> dialogueOptionsBank1 = new Dictionary<int, string>();

    public void fillBank1() {

        # region Cutscene 2
        
        dialogueOptionsBank1.Add(0, "Buy apple");
        dialogueOptionsBank1.Add(1, "Buy orange");
        dialogueOptionsBank1.Add(2, "Buy banana");
        #endregion
    }
}