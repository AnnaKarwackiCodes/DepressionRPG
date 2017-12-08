using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalStuff {
    private static Vector3 prevPos;
    private static bool wasInBattle;
    private static bool[] baddiesAlive;
    private static int curFight;
    private static bool aniexty;
    private static int anxTalk;
    private static bool kindFinished;
    private static bool overThinkingStart;
	private static bool wizFinished;
	private static bool talkToWiz;
	private static bool useSpell;
	private static bool haveQuestItem;
	private static bool kindSpeak;
    private static bool isPaused;
    private static int entriesUnlocked;
    private static bool getAlert;
    private static bool curInteractBefore;

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

    public static bool Aniexty {
        get {
            return aniexty;
        }
        set {
            aniexty = value;
        }
    }

    public static int AnxTalk {
        get {
            return anxTalk;
        }
        set {
            anxTalk = value;
        }
    }

    public static bool KindFinished
    {
        set
        {
            kindFinished = value;
        }
        get
        {
            return kindFinished;
        }
    }

	public static bool WizFinished
	{
		set
		{
			wizFinished = value;
		}
		get
		{
			return wizFinished;
		}
	}

	public static bool TalkToWiz
	{
		set
		{
			talkToWiz = value;
		}
		get
		{
			return talkToWiz;
		}
	}

	public static bool UseSpell
	{
		set
		{
			useSpell = value;
		}
		get
		{
			return useSpell;
		}
	}

    public static bool OverthinkingStart
    {
        set
        {
            overThinkingStart = value;
        }
        get
        {
            return overThinkingStart;
        }
    }

	public static bool HaveQuestItem
	{
		set
		{
			haveQuestItem = value;
		}
		get
		{
			return haveQuestItem;
		}
	}
	public static bool KindSpeak{
		set{
			kindSpeak = value;
		}
		get{ 
			return kindSpeak;
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

    public static bool IsPaused
    {
        get { return isPaused; }
        set { isPaused = value; }
    }

    public static int EntriesUnlocked
    {
        get { return entriesUnlocked; }
        set { entriesUnlocked = value; }
    }

    public static bool GetAlert
    {
        get { return getAlert; }
        set { getAlert = value; }
    }

    public static bool CurInteractBefore
    {
        get { return curInteractBefore; }
        set { curInteractBefore = value; }
    }

    public static void reset()
    {
        wasInBattle = false;
        aniexty = true;
        anxTalk = 0;
        kindFinished = false;
        wizFinished = false;
        talkToWiz = false;
        useSpell = false;
        haveQuestItem = false;  
		kindSpeak = false;
        isPaused = false;
        entriesUnlocked = 1;
        getAlert = false;
    }
}
