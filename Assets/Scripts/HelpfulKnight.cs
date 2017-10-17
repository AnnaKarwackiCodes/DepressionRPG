using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpfulKnight : MonoBehaviour {
    public string Name;
    public Sprite look;
    public string[] Dialogue;
    public GameObject textbox;
    public GameObject can;
    public GameObject play;
    private int dialogueSize;
    private bool isCreated = false;
    private GameObject tb;
    private string[] garbage;

    //text stuff
    private int curFrame = 0;
    private bool isUp = true;
    private bool isDown = false;
    // Use this for initialization
    void Start () {
        GetComponent<SpriteRenderer>().sprite = look;
        dialogueSize = Dialogue.Length;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void displayText()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            isUp = true;
            isDown = false;
        }
        else if (Input.GetKeyDown(KeyCode.Return) && isUp)
        {
            isDown = true;
            isUp = false;
            curFrame++;
            play.GetComponent<Player>().CanMove = false;
        }

        if (curFrame > dialogueSize - 1)
        {
            curFrame = 0;
        }
        tb.transform.GetChild(0).GetComponent<Text>().text = Dialogue[curFrame];
    }
}
