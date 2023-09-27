using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    public Cutscene1 cutscene1 = new Cutscene1();

    public class Cutscene1 {
        int idx;
        string text;
        public Dictionary<int, string> cutscene1DiagBank = new Dictionary<int, string>();
        public List<int> portraitBank = new List<int>();

        public void fillBank (DialogueDictionaries diagDict) {
            cutscene1DiagBank.Add(0, diagDict.friend.friendDiagBank[0]);
            portraitBank.Add(4);
            cutscene1DiagBank.Add(1, diagDict.player.playerDiagBank[0]);
            portraitBank.Add(0);
            cutscene1DiagBank.Add(2, diagDict.friend.friendDiagBank[1]);
            portraitBank.Add(4);
            cutscene1DiagBank.Add(3, diagDict.player.playerDiagBank[1]);
            portraitBank.Add(0);
            cutscene1DiagBank.Add(4, diagDict.friend.friendDiagBank[2]);
            portraitBank.Add(4);
            cutscene1DiagBank.Add(5, diagDict.friend.friendDiagBank[3]);
            portraitBank.Add(4);
        }
    }

    // public void Cutscene2() {
    //     int idx;
    //     string text;
    //     Dictionary<int, string> cutscene2DiagBank = new Dictionary<int, string>();
        
    //     cutscene2DiagBank.Add(0, diagDict.player.playerDiagBank[0]);
    //     cutscene2DiagBank.Add(1, diagDict.meangirl1.meangirl1DiagBank[0]);
    //     cutscene2DiagBank.Add(2, diagDict.meangirl2.meangirl2DiagBank[0]);
    //     //call diag options here
    //     //call diag response here
    // }
}
