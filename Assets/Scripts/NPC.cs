using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {
    public string Name;
    public Sprite look;
    public string[] Dialogue;
	public GameObject textbox;
	public GameObject play;
    private int dialogueSize;

	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().sprite = look;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//if the player is within a distance of NPC show dialogue
	void WithinRange(){
		

	}
}
