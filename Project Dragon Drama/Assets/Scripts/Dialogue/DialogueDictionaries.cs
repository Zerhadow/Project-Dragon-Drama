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

    public HotGuy hotGuy = new HotGuy();
}

public class Narrator {
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

        # region Cutscene 8
        narratorDiagBank.Add(idx++, "Nataly mentions something about how one of her horns has been acting up recently and she needs to schedule her monthly Horn visit at her cornologist.");
        #endregion

        # region Cutscene 10
        narratorDiagBank.Add(idx++, "You find Ken who’s awesome and totally sexy and hot, and I’m not talking about his breath.");
        narratorDiagBank.Add(idx++, "The player receives some anti-itch horn cream.");
        narratorDiagBank.Add(idx++, "Sam devises a plan, and gets ready for it.");
        narratorDiagBank.Add(idx++, "Towards the end of the day Sam is walking past Jassica, when suddenly something small slips out of her bag.");
        narratorDiagBank.Add(idx++, "Sam picks up the cream and turns around, she then loudly and audibly gasps in shock at the contents.");
        narratorDiagBank.Add(idx++, "Jassica looks at the cream in Sam’s hand and swipes at Sam’s hand, Sam narrowly avoids the swipe and reads the label aloud.");
        narratorDiagBank.Add(idx++, "Murmurs and whispers begin to fill the hallway. Jassica is stunned in awe at what’s happening.s");
        narratorDiagBank.Add(idx++, "Tears begin to flow down Jassica’s eyes as she runs through the hallway and disappears around a corner.");
        narratorDiagBank.Add(idx++, "As you walk to your next class, you get the feeling to check the bathroom. As you enter you hear sobbing from one of the stalls. And hear faintly");
        narratorDiagBank.Add(idx++, "You knock on the door.");
        narratorDiagBank.Add(idx++, "Jassica opens the stall door.");
        narratorDiagBank.Add(idx++, "Jassica pulls an envelope from her backpack.");
        
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

        #region Cutscene 8
        playerDiagBank.Add(idx++, "The what accident?");
        #endregion

        #region Cutscene 9
        playerDiagBank.Add(idx++, "That’s what she said");
        playerDiagBank.Add(idx++, "Do they have any Exes");
        playerDiagBank.Add(idx++, "Gotcha.");
        #endregion

        #region Cutscene 10
        playerDiagBank.Add(idx++, "Uh. Yeah. Ken, right? Literally everyone knows about you");
        playerDiagBank.Add(idx++, "I’m so sorry.");
        playerDiagBank.Add(idx++, "Wait what?");
        playerDiagBank.Add(idx++, "How’s that been working out?");
        playerDiagBank.Add(idx++, "Are you sure everything’s ok between them?");
        playerDiagBank.Add(idx++, "Was there anything different about her afterwards?");
        playerDiagBank.Add(idx++, "Why the hell would you do that?");
        playerDiagBank.Add(idx++, "You sure?");
        playerDiagBank.Add(idx++, "I think Sam needs to see this.");
        playerDiagBank.Add(idx++, "I honestly don’t know what I’m doing.");
        playerDiagBank.Add(idx++, "Why?");
        playerDiagBank.Add(idx++, "From cream?");
        playerDiagBank.Add(idx++, "Sure, whatever you say.");
        playerDiagBank.Add(idx++, "Oh my god. I’m so sorry");
        playerDiagBank.Add(idx++, "Look, I-");
        playerDiagBank.Add(idx++, "I- I don’t know what to say.");
        playerDiagBank.Add(idx++, "I don’t even know how though.");
        playerDiagBank.Add(idx++, "What is it?");
        playerDiagBank.Add(idx++, "Why do you have this?");
        playerDiagBank.Add(idx++, "Thank you.");
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

        #region Cutscene 9
        friendDiagBank.Add(idx++, "One week?");
        friendDiagBank.Add(idx++, "She’s totally lying, it takes a least a Month to get one to grow back.");
        friendDiagBank.Add(idx++, "Plus with the fact of visiting her cornologist. Which one is it?");
        friendDiagBank.Add(idx++, "So since it’s obviously Jassica, where could we start?");
        friendDiagBank.Add(idx++, "Girl. How, you know what I’m thinkin’?");
        friendDiagBank.Add(idx++, "I know she has one ex, but I Don’t know much about him, try talking around.");
        friendDiagBank.Add(idx++, "And remember, find anything juicy and come talk to me!!");
        #endregion

        #region Cutscene 10
        friendDiagBank.Add(idx++, "Holy cow! You are good at this!");
        friendDiagBank.Add(idx++, "Doesn’t matter! We’re going to use this against her!");
        friendDiagBank.Add(idx++, "Because, this is undeniable proof, that Jassica Got a horn job.");
        friendDiagBank.Add(idx++, "Believe me. It will work.");
        friendDiagBank.Add(idx++, "Jassica!");
        friendDiagBank.Add(idx++, "Why did this slip out of your bag!");
        friendDiagBank.Add(idx++, "Anti-Itch Horn cream? Why would you need that?");
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

        # region Cutscene 8
        meangirl2DiagBank.Add(idx++, "Why do you need to see a farmer?");
        meangirl2DiagBank.Add(idx++, "Yeah, ever since that Football accident.");
        meangirl2DiagBank.Add(idx++, "Yeah my horn grew back in like a week. must be blessed By the genes of my ancestry. Or something.");
        #endregion

        # region Cutscene 10
        meangirl2DiagBank.Add(idx++, "What? What do you want?");
        meangirl2DiagBank.Add(idx++, "It’s for my horn. I need it.");
        meangirl2DiagBank.Add(idx++, "It wasn’t my fault.");
        meangirl2DiagBank.Add(idx++, "Not now Bailey. I don’t want to talk to you!");
        meangirl2DiagBank.Add(idx++, "It wasn't my fault ok? I had to.");
        meangirl2DiagBank.Add(idx++, "After I broke my horn, they told me it wouldn't grow back. Some rare birth defect was the reason.");
        meangirl2DiagBank.Add(idx++, "Yeah, but you had to tell everyone. I don’t know how I’m even going to show my face tomorrow.");
        meangirl2DiagBank.Add(idx++, "I know everyone hates the Smaugs, but it’s really Nataly everyone hates. Even Persia and I.");
        meangirl2DiagBank.Add(idx++, "Look. You already have her trust. If you want to take her down. I say do it.");
        meangirl2DiagBank.Add(idx++, "Here.");
        meangirl2DiagBank.Add(idx++, "It’s a love note, one I wrote for Ken.");
        meangirl2DiagBank.Add(idx++, "After Nataly stole him from me. Right before we broke up. I wrote this as a last ditch effort to try and keep him.");
        meangirl2DiagBank.Add(idx++, "Look. He’s a good guy. He doesn’t deserve Nataly, or me, but you. You might just be what he needs.");
        
        #endregion
    }
}

public class Meangirl3 { // Nataly
    public Dictionary<int, string> meangirl3DiagBank = new Dictionary<int, string>();

    public void fillBank() {
        int idx = 0;

        # region Cutscene 8
        meangirl3DiagBank.Add(idx++, "They’re the doctor’s that take care of your horn oooh yeah I forgot, you haven’t gone to one in ages.");
        meangirl3DiagBank.Add(idx++, "Oh yeah you’re new, you weren’t there.");
        meangirl3DiagBank.Add(idx++, "Or Something.");
        # endregion

        # region Cutscene 10
        meangirl3DiagBank.Add(idx++, "Jassica? What’s the meaning of all this?");
        meangirl3DiagBank.Add(idx++, "Don’t tell me. YOU GOT A HORN JOB?!");
        meangirl3DiagBank.Add(idx++, "I can’t believe her.");
        meangirl3DiagBank.Add(idx++, "I always knew she was a fake.");
        #endregion
    }
}

public class KeyStudent {
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

public class HotGuy {
    public Dictionary<int, string> hotGuyDiagBank = new Dictionary<int, string>();

    public void fillBank() {
        int idx = 0;
        hotGuyDiagBank.Add(idx++, "Oh, Hey! You’re the new girl right?");
        hotGuyDiagBank.Add(idx++, "Not surprised. You get involved with the Smaugs and suddenly everyone knows about you.");
        hotGuyDiagBank.Add(idx++, "Don’t be. Everyone already know’s your name Bailey");
        hotGuyDiagBank.Add(idx++, "Joking, just heard it from Nataly.");
        hotGuyDiagBank.Add(idx++, "It’s alright I guess. I still feel bad for Jassica though.");
        hotGuyDiagBank.Add(idx++, "Well, I can’t be alone in the same room with both of them If that’s what you mean.");
        hotGuyDiagBank.Add(idx++, "Well… she kept this cream around for her horn. I never really asked about it, but after we broke up I kept some of it.");
        hotGuyDiagBank.Add(idx++, "It’s not a creepy memento! It just gives my horns a nice feeling.");
        hotGuyDiagBank.Add(idx++, "I’d be happy to give some to you, Trust me. It’s one of the best feelings Ever! Especially after a good trimming.");
        hotGuyDiagBank.Add(idx++, "Absolutely! I’ve already got some more at my house. I faked a doctor’s note. Pretty sweet right?");
        
    }
}

public class DialogueOptionsText {
    public Dictionary<int, string> dialogueOptionsBank1 = new Dictionary<int, string>();
    public Dictionary<int, string> dialogueOptionsBank2 = new Dictionary<int, string>();
    public Dictionary<int, string> dialogueOptionsBank3 = new Dictionary<int, string>();
    public Dictionary<int, string> dialogueOptionsBank4 = new Dictionary<int, string>();
    public Dictionary<int, string> dialogueOptionsBank5 = new Dictionary<int, string>();
    public Dictionary<int, string> dialogueOptionsBank6 = new Dictionary<int, string>();
    public Dictionary<int, string> dialogueOptionsBank7 = new Dictionary<int, string>();
    

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

    public void fillBank4() {
        dialogueOptionsBank4.Add(0, "Jassica");
        dialogueOptionsBank4.Add(1, "Nataly");
        dialogueOptionsBank4.Add(2, "Sam");
    }

    public void fillBank5() {
        dialogueOptionsBank5.Add(0, "You're SO hot");
        dialogueOptionsBank5.Add(1, "Has one of them mentioned a horn?");
        dialogueOptionsBank5.Add(2, "I want to ask you about Jassica's horn");
    }

    public void fillBank6() {
        dialogueOptionsBank6.Add(0, "Fine! I don't want to talk to you either.");
        dialogueOptionsBank6.Add(1, "Isn't this the time for girl talk?");
        dialogueOptionsBank6.Add(2, "I have some snack in my pocket, lets just talk.");
    }

    public void fillBank7() {
        dialogueOptionsBank7.Add(0, "Why me?");
        dialogueOptionsBank7.Add(1, "Why didn't you give it to him?");
        dialogueOptionsBank7.Add(2, "You got problems");
    }
}