using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    public Cutscene1 cutscene1 = new Cutscene1();
    public Cutscene2 cutscene2 = new Cutscene2();
    public Cutscene3 cutscene3 = new Cutscene3();
    public Cutscene4 cutscene4 = new Cutscene4();
    public Cutscene5 cutscene5 = new Cutscene5();
    public Cutscene6 cutscene6 = new Cutscene6();
    public Cutscene7 cutscene7 = new Cutscene7();
    public Cutscene8 cutscene8 = new Cutscene8();
    public Cutscene9 cutscene9 = new Cutscene9();
    public Cutscene10 cutscene10 = new Cutscene10();
    public Cutscene11 cutscene11 = new Cutscene11();
    public Cutscene12 cutscene12 = new Cutscene12();
    public Cutscene13 cutscene13 = new Cutscene13();

    int narratorIdx = 0, playerIdx = 0, friendIdx = 0, teacherIdx = 0, keyStudentIdx = 0;
    int meangirl1Idx = 0, meangirl2Idx = 0, meangirl3Idx = 0, hotGuyIdx = 0;

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
            int idx = 0, narratorIdx = 7, playerIdx = 17, friendIdx = 13;

            diagBank.Add(idx++, diagDict.narrator.narratorDiagBank[narratorIdx++]);
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
            // Debug.Log("friendIdx: " + friendIdx); // 16
            // Debug.Log("playerIdx: " + playerIdx); // 18
            // Debug.Log("narratorIdx: " + narratorIdx); // 9
        }
    }

    public class Cutscene4 {
        public Dictionary<int, string> diagBank = new Dictionary<int, string>();
        public List<int> portraitBank = new List<int>();

        public void fillBank (DialogueDictionaries diagDict) {
            int idx = 0, narratorIdx = 9, playerIdx = 18, friendIdx = 16, meangirl1Idx = 0, meangirl2Idx = 0, meangirl3Idx = 0;

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
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.friend.friendDiagBank[friendIdx++]);
            portraitBank.Add(4);
            diagBank.Add(idx++, diagDict.friend.friendDiagBank[friendIdx++]);
            portraitBank.Add(4);
            diagBank.Add(idx++, diagDict.friend.friendDiagBank[friendIdx++]);
            portraitBank.Add(4);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.friend.friendDiagBank[friendIdx++]);
            portraitBank.Add(4);
            diagBank.Add(idx++, diagDict.friend.friendDiagBank[friendIdx++]);
            portraitBank.Add(4);
            // Debug.Log("friendIdx: " + friendIdx); // 24
            // Debug.Log("playerIdx: " + playerIdx); // 22
            // Debug.Log("narratorIdx: " + narratorIdx); // 10
        }
    }

    public class Cutscene5 {
        public Dictionary<int, string> diagBank = new Dictionary<int, string>();
        public List<int> portraitBank = new List<int>();

        public void fillBank (DialogueDictionaries diagDict) {
            int idx = 0, narratorIdx = 10, playerIdx = 22, friendIdx = 24, meangirl1Idx = 0, meangirl2Idx = 0, meangirl3Idx = 0;

            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.friend.friendDiagBank[friendIdx++]);
            portraitBank.Add(4);
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
            // Debug.Log("friendIdx: " + friendIdx); // 30
            // Debug.Log("playerIdx: " + playerIdx); // 27
            // Debug.Log("narratorIdx: " + narratorIdx); // 13
        }
    }

    public class Cutscene6 {
        public Dictionary<int, string> diagBank = new Dictionary<int, string>();
        public List<int> portraitBank = new List<int>();

        public void fillBank (DialogueDictionaries diagDict) {
            int idx = 0, narratorIdx = 13, playerIdx = 27, friendIdx = 30, meangirl1Idx = 0, meangirl2Idx = 0, meangirl3Idx = 0;

            diagBank.Add(idx++, diagDict.narrator.narratorDiagBank[narratorIdx++]);
            portraitBank.Add(-1);
            diagBank.Add(idx++, diagDict.narrator.narratorDiagBank[narratorIdx++]);
            portraitBank.Add(-1);
            diagBank.Add(idx++, diagDict.meangirl1.meangirl1DiagBank[meangirl1Idx++]);
            portraitBank.Add(1);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.meangirl1.meangirl1DiagBank[meangirl1Idx++]);
            portraitBank.Add(1);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.meangirl1.meangirl1DiagBank[meangirl1Idx++]);
            portraitBank.Add(1);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.meangirl1.meangirl1DiagBank[meangirl1Idx++]);
            portraitBank.Add(1);
            diagBank.Add(idx++, diagDict.meangirl1.meangirl1DiagBank[meangirl1Idx++]);
            portraitBank.Add(1);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.meangirl1.meangirl1DiagBank[meangirl1Idx++]);
            portraitBank.Add(1);
            diagBank.Add(idx++, diagDict.narrator.narratorDiagBank[narratorIdx++]);
            portraitBank.Add(-1);
            // Debug.Log("friendIdx: " + friendIdx); // 30
            // Debug.Log("playerIdx: " + playerIdx); // 31
            // Debug.Log("narratorIdx: " + narratorIdx); // 16
        }
    }

    public class Cutscene7 {
        public Dictionary<int, string> diagBank = new Dictionary<int, string>();
        public List<int> portraitBank = new List<int>();

        public void fillBank (DialogueDictionaries diagDict) {
            int idx = 0, narratorIdx = 16, playerIdx = 31, friendIdx = 30, meangirl1Idx = 0, meangirl2Idx = 0, meangirl3Idx = 0;

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
            // Debug.Log("Idx: " + idx); Need to get idx to tell CSC Controller
            //Response to Diag Option
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
            diagBank.Add(idx++, diagDict.narrator.narratorDiagBank[narratorIdx++]);
            portraitBank.Add(-1);
            diagBank.Add(idx++, diagDict.meangirl2.meangirl2DiagBank[meangirl2Idx++]);
            portraitBank.Add(2);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.meangirl2.meangirl2DiagBank[meangirl2Idx++]);
            portraitBank.Add(2);
            // Debug.Log("Idx: " + idx); // Need to get idx to tell CSC Controller
            //Response to Diag Option
            diagBank.Add(idx++, diagDict.meangirl2.meangirl2DiagBank[meangirl2Idx++]);
            portraitBank.Add(2);
            diagBank.Add(idx++, diagDict.meangirl2.meangirl2DiagBank[meangirl2Idx++]);
            // Debug.Log("Idx: " + idx); // Need to get idx to tell CSC Controller
            //Response to Diag Option
            portraitBank.Add(2);
            diagBank.Add(idx++, diagDict.meangirl2.meangirl2DiagBank[meangirl2Idx++]);
            portraitBank.Add(2);
            diagBank.Add(idx++, diagDict.narrator.narratorDiagBank[narratorIdx++]);
            portraitBank.Add(-1);
            diagBank.Add(idx++, diagDict.narrator.narratorDiagBank[narratorIdx++]);
            portraitBank.Add(-1);
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
            // Debug.Log("NarratorIdx: " + narratorIdx); // 22
            // Debug.Log("friendIdx: " + friendIdx); // 46
            // Debug.Log("playerIdx: " + playerIdx); // 44
            // Debug.Log("meangirl2Idx: " + meangirl2Idx); // 5
        }

        public string GetOptionResponse(int idx) {
            if(idx == 1) {
                return "Perfect I was hoping You would say that.";
            } else if(idx == 2) {
                return "It’s too late to back out. I think if you don’t take them out, now. You might have to move again.";
            } else if(idx == 3) {
                return "I'll take that as a yes.";
            } else {
                return "I'll take that as a yes.";
            }
        }

        public string GetOptionResponse2(int idx) {
            if(idx == 1) {
                return "Oh perfect, we’ll both be waiting for you during lunch";
            } else if(idx == 2) {
                return "Fine, but if you change your mind, you can come sit with us at lunch.";
            } else if(idx == 3) {
                return "Fine, but if you change your mind, you can come sit with us at lunch.";
            } else {
                return "I'm not sure if I can do this.";
            }
        }
    }

    public class Cutscene8 {
        public Dictionary<int, string> diagBank = new Dictionary<int, string>();
        public List<int> portraitBank = new List<int>();

        public void fillBank (DialogueDictionaries diagDict) {
            int idx = 0, narratorIdx = 22, playerIdx = 44, friendIdx = 46, meangirl1Idx = 0, meangirl2Idx = 5, meangirl3Idx = 0;

            diagBank.Add(idx++, diagDict.narrator.narratorDiagBank[narratorIdx++]);
            portraitBank.Add(-1);
            diagBank.Add(idx++, diagDict.meangirl2.meangirl2DiagBank[meangirl2Idx++]);
            portraitBank.Add(2);
            diagBank.Add(idx++, diagDict.meangirl3.meangirl3DiagBank[meangirl3Idx++]);
            portraitBank.Add(3);
            diagBank.Add(idx++, diagDict.meangirl2.meangirl2DiagBank[meangirl2Idx++]);
            portraitBank.Add(2);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.meangirl3.meangirl3DiagBank[meangirl3Idx++]);
            portraitBank.Add(3);
            diagBank.Add(idx++, diagDict.meangirl2.meangirl2DiagBank[meangirl2Idx++]);
            portraitBank.Add(2);
            diagBank.Add(idx++, diagDict.meangirl3.meangirl3DiagBank[meangirl3Idx++]);
            portraitBank.Add(3);
            // Debug.Log("meangirl2Idx: " + meangirl2Idx); // 8
            // Debug.Log("meangirl3Idx: " + meangirl3Idx); // 3
            // Debug.Log("playerIdx: " + playerIdx); // 45
            // Debug.Log("friendIdx: " + friendIdx); // 46
            // Debug.Log("narratorIdx: " + narratorIdx); // 23
        }
    }

    public class Cutscene9 {
        public Dictionary<int, string> diagBank = new Dictionary<int, string>();
        public List<int> portraitBank = new List<int>();

        public void fillBank (DialogueDictionaries diagDict) {
            int idx = 0, narratorIdx = 23, playerIdx = 45, friendIdx = 46, meangirl1Idx = 0, meangirl2Idx = 8, meangirl3Idx = 3;

            diagBank.Add(idx++, diagDict.friend.friendDiagBank[friendIdx++]);
            portraitBank.Add(4);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.friend.friendDiagBank[friendIdx++]);
            portraitBank.Add(4);
            diagBank.Add(idx++, diagDict.friend.friendDiagBank[friendIdx++]);
            portraitBank.Add(4);
            // Debug.Log("Idx: " + idx); Need to get idx to tell CSC Controller
            //Response to Diag Option
            diagBank.Add(idx++, diagDict.friend.friendDiagBank[friendIdx++]);
            portraitBank.Add(4);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.friend.friendDiagBank[friendIdx++]);
            portraitBank.Add(4);
            diagBank.Add(idx++, diagDict.friend.friendDiagBank[friendIdx++]);
            portraitBank.Add(4);
            diagBank.Add(idx++, diagDict.friend.friendDiagBank[friendIdx++]);
            portraitBank.Add(4);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            // Debug.Log("friendIdx: " + friendIdx); // 53
            // Debug.Log("playerIdx: " + playerIdx); // 48
            // Debug.Log("narratorIdx: " + narratorIdx); // 23
        }

        public string GetOptionResponse(int idx) {
            if(idx == 1) {
                return "Yeah that would add up.";
            } else if(idx == 2) {
                return "Are you serious? It’s obviously Jassica.";
            } else if(idx == 3) {
                return "What the hell? I thought we were friends.";
            } else {
                return "I'll take that as a yes.";
            }
        }
    }

    public class Cutscene10 {
        public Dictionary<int, string> diagBank = new Dictionary<int, string>();
        public List<int> portraitBank = new List<int>();

        public void fillBank (DialogueDictionaries diagDict) {
            int idx = 0, playerIdx = 48, friendIdx = 53, meangirl1Idx = 0, meangirl2Idx = 8, meangirl3Idx = 3, narratorIdx = 23, hotGuyIdx = 0;

            diagBank.Add(idx++, diagDict.narrator.narratorDiagBank[narratorIdx++]);
            portraitBank.Add(-1);
            diagBank.Add(idx++, diagDict.hotGuy.hotGuyDiagBank[hotGuyIdx++]);
            portraitBank.Add(5);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.hotGuy.hotGuyDiagBank[hotGuyIdx++]);
            portraitBank.Add(5);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.hotGuy.hotGuyDiagBank[hotGuyIdx++]);
            portraitBank.Add(5);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.hotGuy.hotGuyDiagBank[hotGuyIdx++]);
            portraitBank.Add(5);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.hotGuy.hotGuyDiagBank[hotGuyIdx++]);
            portraitBank.Add(5);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.hotGuy.hotGuyDiagBank[hotGuyIdx++]);
            portraitBank.Add(5);
            // Debug.Log("Idx: " + idx); // Need to get idx to tell CSC Controller
            //Response to Diag Option
            diagBank.Add(idx++, diagDict.hotGuy.hotGuyDiagBank[hotGuyIdx++]);
            portraitBank.Add(5);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]); 
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.hotGuy.hotGuyDiagBank[hotGuyIdx++]);
            portraitBank.Add(5);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.hotGuy.hotGuyDiagBank[hotGuyIdx++]);
            portraitBank.Add(5);
            diagBank.Add(idx++, diagDict.hotGuy.hotGuyDiagBank[hotGuyIdx++]);
            portraitBank.Add(5);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.hotGuy.hotGuyDiagBank[hotGuyIdx++]);
            portraitBank.Add(5);
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
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.narrator.narratorDiagBank[narratorIdx++]);
            portraitBank.Add(-1);
            diagBank.Add(idx++, diagDict.narrator.narratorDiagBank[narratorIdx++]);
            portraitBank.Add(-1);
            diagBank.Add(idx++, diagDict.narrator.narratorDiagBank[narratorIdx++]);
            portraitBank.Add(-1);
            diagBank.Add(idx++, diagDict.friend.friendDiagBank[friendIdx++]);
            portraitBank.Add(4);
            diagBank.Add(idx++, diagDict.meangirl2.meangirl2DiagBank[meangirl2Idx++]);
            portraitBank.Add(2);
            diagBank.Add(idx++, diagDict.friend.friendDiagBank[friendIdx++]);
            portraitBank.Add(4);
            diagBank.Add(idx++, diagDict.narrator.narratorDiagBank[narratorIdx++]);
            portraitBank.Add(-1);
            diagBank.Add(idx++, diagDict.friend.friendDiagBank[friendIdx++]);
            portraitBank.Add(4);
            diagBank.Add(idx++, diagDict.narrator.narratorDiagBank[narratorIdx++]);
            portraitBank.Add(-1);
            diagBank.Add(idx++, diagDict.meangirl3.meangirl3DiagBank[meangirl3Idx++]);
            portraitBank.Add(3);
            diagBank.Add(idx++, diagDict.meangirl2.meangirl2DiagBank[meangirl2Idx++]);
            portraitBank.Add(2);
            diagBank.Add(idx++, diagDict.meangirl3.meangirl3DiagBank[meangirl3Idx++]);
            portraitBank.Add(3);
            diagBank.Add(idx++, diagDict.narrator.narratorDiagBank[narratorIdx++]);
            portraitBank.Add(-1);
            diagBank.Add(idx++, diagDict.meangirl3.meangirl3DiagBank[meangirl3Idx++]);
            portraitBank.Add(3);
            diagBank.Add(idx++, diagDict.meangirl3.meangirl3DiagBank[meangirl3Idx++]);
            portraitBank.Add(3);
            diagBank.Add(idx++, diagDict.narrator.narratorDiagBank[narratorIdx++]);
            portraitBank.Add(-1);
            diagBank.Add(idx++, diagDict.meangirl2.meangirl2DiagBank[meangirl2Idx++]);
            portraitBank.Add(2);
            diagBank.Add(idx++, diagDict.narrator.narratorDiagBank[narratorIdx++]);
            portraitBank.Add(-1);
            diagBank.Add(idx++, diagDict.meangirl2.meangirl2DiagBank[meangirl2Idx++]);
            portraitBank.Add(2);
            // Debug.Log("Idx: " + idx); // Need to get idx to tell CSC Controller
            //Response to Diag Option
            diagBank.Add(idx++, diagDict.meangirl2.meangirl2DiagBank[meangirl2Idx++]);
            portraitBank.Add(2);
            diagBank.Add(idx++, diagDict.narrator.narratorDiagBank[narratorIdx++]);
            portraitBank.Add(-1);
            diagBank.Add(idx++, diagDict.meangirl2.meangirl2DiagBank[meangirl2Idx++]);
            portraitBank.Add(2);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]); 
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.meangirl2.meangirl2DiagBank[meangirl2Idx++]); 
            portraitBank.Add(2);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]); 
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.meangirl2.meangirl2DiagBank[meangirl2Idx++]);
            portraitBank.Add(2);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.meangirl2.meangirl2DiagBank[meangirl2Idx++]); 
            portraitBank.Add(2);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.narrator.narratorDiagBank[narratorIdx++]);
            portraitBank.Add(-1);
            diagBank.Add(idx++, diagDict.meangirl2.meangirl2DiagBank[meangirl2Idx++]);
            portraitBank.Add(2);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.meangirl2.meangirl2DiagBank[meangirl2Idx++]);
            portraitBank.Add(2);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.meangirl2.meangirl2DiagBank[meangirl2Idx++]);
            portraitBank.Add(2);
            
            // Debug.Log("Idx: " + idx); // Need to get idx to tell CSC Controller
            //Response to Diag Option
            diagBank.Add(idx++, diagDict.meangirl2.meangirl2DiagBank[meangirl2Idx++]);
            portraitBank.Add(2);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.meangirl2.meangirl2DiagBank[meangirl2Idx++]);
            portraitBank.Add(2);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.meangirl2.meangirl2DiagBank[meangirl2Idx++]);
            portraitBank.Add(2);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.meangirl2.meangirl2DiagBank[meangirl2Idx++]);
            portraitBank.Add(2);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            diagBank.Add(idx++, diagDict.meangirl2.meangirl2DiagBank[meangirl2Idx++]);
            portraitBank.Add(2);
            // Debug.Log("FriendIdx: " + friendIdx); // 60
            // Debug.Log("PlayerIdx: " + playerIdx); // 71
            // Debug.Log("NarratorIdx: " + narratorIdx); // 35
            // Debug.Log("Meangirl2Idx: " + meangirl2Idx); // 25
            // Debug.Log("Meangirl3Idx: " + meangirl3Idx); // 7
            // Debug.Log("HotGuyIdx: " + hotGuyIdx); // 11
        }

        public string GetOptionResponse(int idx) {
            if(idx == 1) {
                return "What? I'm guessing you're talking about Jassica's horn.";
            } else if(idx == 2) {
                return "I think Jassica maybe";
            } else if(idx == 3) {
                return "Yeah her horn. I was with her when she broke it.";
            } else {
                return "I’m sorry, I didn’t mean to stare.";
            }
        }

        public string GetOptionResponse2(int idx) {
            if(idx == 1) {
                return "No, please stay";
            } else if(idx == 2) {
                return "Alright fine";
            } else if(idx == 3) {
                return "… Ok.";
            } else {
                return "I’m sorry, I didn’t mean to stare.";
            }
        }

        public string GetOptionResponse3(int idx) {
            if(idx == 1) {
                return "You are interested in him. Duh";
            } else if(idx == 2) {
                return "I was too late.";
            } else if(idx == 3) {
                return "Of course, newt. We all do.";
            } else {
                return "I’m sorry, I didn’t mean to stare.";
            }
        }
    }

    public class Cutscene11 {
        public Dictionary<int, string> diagBank = new Dictionary<int, string>();
        public List<int> portraitBank = new List<int>();

        public void fillBank (DialogueDictionaries diagDict) {
            int idx = 0, playerIdx = 71, friendIdx = 60, meangirl1Idx = 0, meangirl2Idx = 25, meangirl3Idx = 7, narratorIdx = 35, hotGuyIdx = 11;

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
            diagBank.Add(idx++, diagDict.friend.friendDiagBank[friendIdx++]);
            portraitBank.Add(4);
            diagBank.Add(idx++, diagDict.friend.friendDiagBank[friendIdx++]);
            portraitBank.Add(4);
            diagBank.Add(idx++, diagDict.narrator.narratorDiagBank[narratorIdx++]);
            portraitBank.Add(-1);
            diagBank.Add(idx++, diagDict.narrator.narratorDiagBank[narratorIdx++]);
            portraitBank.Add(-1);
            diagBank.Add(idx++, diagDict.narrator.narratorDiagBank[narratorIdx++]);
            portraitBank.Add(-1);
            diagBank.Add(idx++, diagDict.player.playerDiagBank[playerIdx++]);
            portraitBank.Add(0);
            // Debug.Log("FriendIdx: " + friendIdx); // 68
            // Debug.Log("PlayerIdx: " + playerIdx); // 78
            // Debug.Log("NarratorIdx: " + narratorIdx); // 38
            
        }
    }

    public class Cutscene12 {
        public Dictionary<int, string> diagBank = new Dictionary<int, string>();
        public List<int> portraitBank = new List<int>();

        public void fillBank (DialogueDictionaries diagDict) {
            int idx = 0, playerIdx = 78, friendIdx = 68, meangirl1Idx = 0, meangirl2Idx = 25, meangirl3Idx = 7, narratorIdx = 38, hotGuyIdx = 11;

        }
    }

    public class Cutscene13 {
        public Dictionary<int, string> diagBank = new Dictionary<int, string>();
        public List<int> portraitBank = new List<int>();

        public void fillBank (DialogueDictionaries diagDict) {

        }
    }
}
