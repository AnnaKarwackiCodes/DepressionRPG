using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {
    public string Name;
    public Sprite look;
    public string[] Dialogue;
    private int dialogueSize;

	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().sprite = look;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
