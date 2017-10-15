using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalStuff {
    private static Vector3 prevPos;
    private static bool wasInBattle;
    private static bool[] baddiesAlive;
    private static int curFight;

    public static Vector3 PrevPos {
        get {
            return prevPos;
        }
        set {
            prevPos = value;
        }
    }

    public static bool WasInBattle {
       get {
            return wasInBattle;
        }
        set {
            wasInBattle = value;
        }
    }

    public static int CurFight {
        get {
            return curFight;
        }
        set {
            curFight = value;
        }
    }

    public static void setBaddieOne(int length) {
        baddiesAlive = new bool[length];

        for (int i = 0; i < length; i++) {
            baddiesAlive[i] = true;
        } 
    }

    public static void changeBaddie(int num, bool value) {
        baddiesAlive[num] = value;
    }

    public static bool getBaddie(int pos) {
        return baddiesAlive[pos];
    }
}
