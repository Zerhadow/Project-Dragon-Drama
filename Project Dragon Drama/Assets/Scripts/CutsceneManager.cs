using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    public Cutscene1 cutscene1 = new Cutscene1();
    public Cutscene2 cutscene2 = new Cutscene2();

    public class Cutscene1 {
        int idx;
        string text;
        public Dictionary<int, string> diagBank = new Dictionary<int, string>();
        public List<int> portraitBank = new List<int>();

        public void fillBank (DialogueDictionaries diagDict) {
            diagBank.Add(0, diagDict.friend.friendDiagBank[0]);
            portraitBank.Add(4);
            diagBank.Add(1, diagDict.player.playerDiagBank[0]);
            portraitBank.Add(0);
            diagBank.Add(2, diagDict.friend.friendDiagBank[1]);
            portraitBank.Add(4);
            diagBank.Add(3, diagDict.player.playerDiagBank[1]);
            portraitBank.Add(0);
            diagBank.Add(4, diagDict.friend.friendDiagBank[2]);
            portraitBank.Add(4);
            diagBank.Add(5, diagDict.friend.friendDiagBank[3]);
            portraitBank.Add(4);
        }
    }

    public class Cutscene2 {
        int idx;
        string text;
        public Dictionary<int, string> diagBank = new Dictionary<int, string>();
        public List<int> portraitBank = new List<int>();

        public void fillBank (DialogueDictionaries diagDict) {
            diagBank.Add(0, diagDict.friend.friendDiagBank[4]);
            portraitBank.Add(4);
            diagBank.Add(1, diagDict.player.playerDiagBank[3]);
            portraitBank.Add(0);
            diagBank.Add(2, diagDict.friend.friendDiagBank[5]);
            portraitBank.Add(4);
            diagBank.Add(3, "Well that's a weird thing to say.");
            portraitBank.Add(4);
            portraitBank.Add(4);
        }
    }
}
