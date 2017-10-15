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
        
	}

    //respawn into proper place 
    private void Respawn() {
        player.transform.position = GlobalStuff.PrevPos;
    }


}
