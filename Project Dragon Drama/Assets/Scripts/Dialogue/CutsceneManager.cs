using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    public Cutscene1 cutscene1 = new Cutscene1();
    public Cutscene2 cutscene2 = new Cutscene2();
    public Cutscene3 cutscene3 = new Cutscene3();

    int narratorIdx = 0, playerIdx = 0, friendIdx = 0, teacherIdx = 0, keyStudentIdx = 0, meangirl1Idx = 0, meangirl2Idx = 0, meangirl3Idx = 0;

    public class Cutscene1 {
        public Dictionary<int, string> diagBank = new Dictionary<int, string>();
        public List<int> portraitBank = new List<int>();

        public void fillBank (DialogueDictionaries diagDict) {
            int idx = 0, narratorIdx = 0, playerIdx = 0, friendIdx = 0, teacherIdx = 0;

            diagBank.Add(idx++, diagDict.narrator.narratorDiagBank[narratorIdx++]);
            portraitBank.Add(-1);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.narrator.narratorDiagBank[narratorIdx++]);
            portraitBank.Add(-1);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.narrator.narratorDiagBank[narratorIdx++]);
            portraitBank.Add(-1);
            diagBank.Add(idx++, diagDict.narrator.narratorDiagBank[narratorIdx++]);
            portraitBank.Add(-1);
            diagBank.Add(idx++, diagDict.friend.friendDiagBank[friendIdx++]);
            portraitBank.Add(4);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.friend.friendDiagBank[friendIdx++]);
            portraitBank.Add(4);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.friend.friendDiagBank[friendIdx++]);
            portraitBank.Add(4);
            diagBank.Add(idx++, diagDict.friend.friendDiagBank[friendIdx++]);
            portraitBank.Add(4);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.friend.friendDiagBank[friendIdx++]);
            portraitBank.Add(4);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.narrator.narratorDiagBank[narratorIdx++]);
            portraitBank.Add(-1);
            diagBank.Add(idx++, diagDict.teacher.teacherDiagBank[teacherIdx++]);
            portraitBank.Add(-1);
            diagBank.Add(idx++, diagDict.friend.friendDiagBank[friendIdx++]);
            portraitBank.Add(4);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.friend.friendDiagBank[friendIdx++]);
            portraitBank.Add(4);
            diagBank.Add(idx++, diagDict.narrator.narratorDiagBank[narratorIdx++]);
            portraitBank.Add(-1);
            diagBank.Add(idx++, diagDict.friend.friendDiagBank[friendIdx++]);
            portraitBank.Add(4);
            diagBank.Add(idx++, diagDict.narrator.narratorDiagBank[narratorIdx++]);
            portraitBank.Add(-1);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.friend.friendDiagBank[friendIdx++]);
            portraitBank.Add(4);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.friend.friendDiagBank[friendIdx++]);
            portraitBank.Add(4);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.friend.friendDiagBank[friendIdx++]);
            portraitBank.Add(4);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.friend.friendDiagBank[friendIdx++]);
            portraitBank.Add(4);
            diagBank.Add(idx++, diagDict.friend.friendDiagBank[friendIdx++]);
            portraitBank.Add(4);
            // Debug.Log("friendIdx: " + friendIdx); // 13
            // Debug.Log("playerIdx: " + playerIdx); // 11
            // Debug.Log("narratorIdx: " + narratorIdx); // 7
            // Debug.Log("teacherIdx: " + teacherIdx); // 1
        }
    }

    public class Cutscene2 {
        public Dictionary<int, string> diagBank = new Dictionary<int, string>();
        public List<int> portraitBank = new List<int>();

        public void fillBank (DialogueDictionaries diagDict) {
            int idx = 0, narratorIdx = 7, playerIdx = 11, keyStudentIdx = 0;

            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.keyStudent.keyStudentDiagBank[keyStudentIdx++]);
            portraitBank.Add(-1);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.keyStudent.keyStudentDiagBank[keyStudentIdx++]);
            portraitBank.Add(-1);
            diagBank.Add(idx++, diagDict.keyStudent.keyStudentDiagBank[keyStudentIdx++]);
            portraitBank.Add(-1);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.keyStudent.keyStudentDiagBank[keyStudentIdx++]);
            portraitBank.Add(-1);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.keyStudent.keyStudentDiagBank[keyStudentIdx++]);
            portraitBank.Add(-1);
            diagBank.Add(idx++, diagDict.keyStudent.keyStudentDiagBank[keyStudentIdx++]);
            portraitBank.Add(-1);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.keyStudent.keyStudentDiagBank[keyStudentIdx++]);
            portraitBank.Add(-1);
            diagBank.Add(idx++, diagDict.keyStudent.keyStudentDiagBank[keyStudentIdx++]);
            portraitBank.Add(-1);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.keyStudent.keyStudentDiagBank[keyStudentIdx++]);
            portraitBank.Add(-1);
            diagBank.Add(idx++, diagDict.keyStudent.keyStudentDiagBank[keyStudentIdx++]);
            portraitBank.Add(-1);
            
            // Debug.Log("playerIdx: " + playerIdx); // 11
            // Debug.Log("keyStudentIdx: " + keyStudentIdx); // 15
        }
    }

    public class Cutscene3 {
        public Dictionary<int, string> diagBank = new Dictionary<int, string>();
        public List<int> portraitBank = new List<int>();

        public void fillBank (DialogueDictionaries diagDict) {
            int idx = 0, narratorIdx = 7, playerIdx = 11, meangirl1Idx = 0, meangirl2Idx = 0, meangirl3Idx = 0;

            diagBank.Add(idx++, diagDict.meangirl1.meangirl1DiagBank[meangirl1Idx++]);
            portraitBank.Add(1);
            
        }
    }
}
