using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject textbox;
    public GameObject player;
    public GameObject[] baddies;
	// Use this for initialization
	void Start () {
        if (GlobalStuff.WasInBattle)
        {
            Respawn();
            GlobalStuff.WasInBattle = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (GlobalStuff.Aniexty == true)
        {
            if (GlobalStuff.AnxTalk >= 3)
            {
                //summon other knight
                spawnKnight();
                //set anxtalk to weird number
                GlobalStuff.AnxTalk = -1;
                //set aniexty to false
                GlobalStuff.Aniexty = false;
            }
        }
	}

    //respawn into proper place 
    private void Respawn() {
        player.transform.position = GlobalStuff.PrevPos;
    }

    private void spawnKnight() {
        
    }


}
