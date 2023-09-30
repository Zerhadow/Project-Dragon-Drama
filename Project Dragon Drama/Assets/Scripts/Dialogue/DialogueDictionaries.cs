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

        # region Cutscene 5
        narratorDiagBank.Add(idx++, "You give Sam a note from Persia's Father");
        narratorDiagBank.Add(idx++, "The note details how much in debt their family is and how she needs to quit spending her money on such frivolous things, , and assist in helping the family.");
        narratorDiagBank.Add(idx++, "A few hours pass. Suddenly an uproar of noise comes from the hallways.");
        #endregion

        # region Cutscene 6
        narratorDiagBank.Add(idx++, "As you walk away to leave the commotion you get a faint look of Persia in the distance. She’s broken, running away, attempting to escape from the truth that’s come to bite her.");
        narratorDiagBank.Add(idx++, "Persia Approaches You");
        narratorDiagBank.Add(idx++, "Persia dashes away. Leaving Bailey befuddled with that last line. It couldn’t just mean nothing. Could it?");
        #endregion

        # region Cutscene 7
        narratorDiagBank.Add(idx++, "The next day, Sam approaches you again.");
        narratorDiagBank.Add(idx++, "Sam quickly moves away from Bailey as Jassica one of the Smaugs approaches.");
        narratorDiagBank.Add(idx++, "The literary teacher spouts something on and on about some book called “The Art of War, by Sun who or something”, although");
        narratorDiagBank.Add(idx++, "although the only thing you could think about was the opportunity that came into your lap.");
        narratorDiagBank.Add(idx++, "The only line you can remember from the lecture was “The opportunity of defeating the enemy is provided by the enemy himself”");
        narratorDiagBank.Add(idx++, "After class, Sam approaches you.");
        
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

        #region Cutscene 5
        playerDiagBank.Add(idx++, "Sleep well?");
        playerDiagBank.Add(idx++, "Don’t you want to know how I found it?");
        playerDiagBank.Add(idx++, "I don’t think I want to do that.");
        playerDiagBank.Add(idx++, "Did we really do something good?");
        playerDiagBank.Add(idx++, "Ok…");
        #endregion

        #region Cutscene 6
        playerDiagBank.Add(idx++, "What?");
        playerDiagBank.Add(idx++, "Wasn’t it based on a lie though?");
        playerDiagBank.Add(idx++, "I just got here, you really think I could’ve done all of that in one day?");
        playerDiagBank.Add(idx++, "What? That’s so obscure");
        #endregion

        #region Cutscene 7
        playerDiagBank.Add(idx++, "So, what?");
        playerDiagBank.Add(idx++, "I guess..");
        playerDiagBank.Add(idx++, "And?");
        playerDiagBank.Add(idx++, "Just the typical “You ruined my life” I mean come on, our lives haven’t even started yet.");
        playerDiagBank.Add(idx++, "Are they all like that?");
        playerDiagBank.Add(idx++, "Ew.");
        playerDiagBank.Add(idx++, "So, what now?");
        playerDiagBank.Add(idx++, "She did mention something along the lines of “at least I don’t have a fake horn”");
        playerDiagBank.Add(idx++, "I mean, that doesn’t make any sense why would anyone have a fake horn?");
        playerDiagBank.Add(idx++, "What?");
        playerDiagBank.Add(idx++, "Those are REAL??");
        playerDiagBank.Add(idx++, "It’s Bailey, and what do you want?");
        playerDiagBank.Add(idx++, "Jassica invited me to sit with them at lunch");
        
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

        #region Cutscene 5
        friendDiagBank.Add(idx++, "Oh totally! You find anything");
        friendDiagBank.Add(idx++, "Oh my god, the rumor is true!");
        friendDiagBank.Add(idx++, "Oh I could care less how you found it. Let’s just go show this off to people and everyone will See how much of a liar she is!");
        friendDiagBank.Add(idx++, "Oh it’s fine, I’ll just make a few copies and post this everywhere. Thanks! You did good!");
        friendDiagBank.Add(idx++, "And now we watch.");
        friendDiagBank.Add(idx++, "Of course we did! They’re bitches.");
        #endregion

        #region Cutscene 7
        friendDiagBank.Add(idx++, "Sooooo?");
        friendDiagBank.Add(idx++, "Oh come on, we took down one of the Smaugs in one day, and your just going to quit there?");
        friendDiagBank.Add(idx++, "Plus, I saw Persia talking to you yesterday");
        friendDiagBank.Add(idx++, "What did she say?");
        friendDiagBank.Add(idx++, "See what I mean? Girl has 2000 years left and she thinks that her world’s over when she’s 15.");
        friendDiagBank.Add(idx++, "Honestly? She was the best.");
        friendDiagBank.Add(idx++, "So what do you say? Wanna take them out?");
        friendDiagBank.Add(idx++, "You’re coming along then.");
        friendDiagBank.Add(idx++, "Well, are you sure she didn’t mention anything off? She always had a loose tongue");
        friendDiagBank.Add(idx++, "A fake horn?");
        friendDiagBank.Add(idx++, "Bailey.");
        friendDiagBank.Add(idx++, "You do know what a horn job is? Don’t you?");
        friendDiagBank.Add(idx++, "Of course they’re real, they aren’t like unicorns");
        friendDiagBank.Add(idx++, "Uhoh. Smaugs at 6 o’clock");
        friendDiagBank.Add(idx++, "Hey what was that at the start of class?");
        friendDiagBank.Add(idx++, "What? This is perfect! Now you can figure out who has the Horn job.");
        #endregion
    }
}

public class Meangirl1 { // Persia
    public Dictionary<int, string> meangirl1DiagBank = new Dictionary<int, string>();

    public void fillBank() {
        int idx = 0;

        # region Custscene 6
        meangirl1DiagBank.Add(idx++, "It was totally you wasn’t it.");
        meangirl1DiagBank.Add(idx++, "You told everyone I’m broke. Got me kicked out of the Smaugs. Everything in my life. Ruined, in just one day.");
        meangirl1DiagBank.Add(idx++, "That part doesn’t matter!");
        meangirl1DiagBank.Add(idx++, "Say what you like, but I will have my suspicions.");
        meangirl1DiagBank.Add(idx++, "I may be broke, but at least my horn isn’t fake");
        meangirl1DiagBank.Add(idx++, "Uh oh! Forget that last part.");
        # endregion
    }
}

public class Meangirl2 { //Jassica
    public Dictionary<int, string> meangirl2DiagBank = new Dictionary<int, string>();

    public void fillBank() {
        int idx = 0;

        # region Cutscene 7
        meangirl2DiagBank.Add(idx++, "Hey you! Hailey was it?");
        meangirl2DiagBank.Add(idx++, "Oh I just came over to congratulate you for taking down Persia.");
        meangirl2DiagBank.Add(idx++, "Oh please there’s no point in hiding it. It was all so obvious, besides. With her gone, we need a new Smaug to join her.");
        meangirl2DiagBank.Add(idx++, "And who better than the very girl who took her down. What do you say? Care to join?");
        meangirl2DiagBank.Add(idx++, "See you there!");
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
    public Dictionary<int, string> dialogueOptionsBank2 = new Dictionary<int, string>();
    public Dictionary<int, string> dialogueOptionsBank3 = new Dictionary<int, string>();

    public void fillBank1() { // for cutscene 7

        dialogueOptionsBank1.Add(0, "Yes");
        dialogueOptionsBank1.Add(1, "No");
        dialogueOptionsBank1.Add(2, "*Incoherent Grumbling*");
    }

    public void fillBank2() {
        dialogueOptionsBank2.Add(0, "How did you know?");
        dialogueOptionsBank2.Add(1, "What are you talking about?");
        dialogueOptionsBank2.Add(2, "F you. Leave me alone");
    }

    public void fillBank3() {
        dialogueOptionsBank3.Add(0, "Yes");
        dialogueOptionsBank3.Add(1, "No");
        dialogueOptionsBank3.Add(2, "I thought I told you to stop talking to me");
    }


}