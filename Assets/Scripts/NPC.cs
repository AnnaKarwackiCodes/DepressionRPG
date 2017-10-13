using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour {
    public string Name;
    public Sprite look;
    public string[] Dialogue;
	public GameObject textbox;
	public GameObject can;
	public GameObject play;
    private int dialogueSize;
    private bool isCreated = false;
	private GameObject tb;

	//text stuff
	private int curFrame = 0;
	private bool isUp = true;
	private bool isDown = false;

	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().sprite = look;
        dialogueSize = Dialogue.Length;
        Debug.Log(dialogueSize);
    }
	
	// Update is called once per frame
	void Update () {
        WithinRange();
	}

	//if the player is within a distance of NPC show dialogue
	void WithinRange(){
        float distance = Mathf.Pow(play.transform.position.x - transform.position.x, 2) + Mathf.Pow(play.transform.position.y - transform.position.y, 2);
        distance = Mathf.Sqrt(distance);

        if (distance < 3)
        {
            if (isCreated == false) {
				tb = Instantiate(textbox, new Vector2(Screen.width/2,Screen.height/6f), new Quaternion(0,0,0,0), can.transform);
                isCreated = true;
            }
            tb.transform.GetChild(0).GetComponent<Text>().text = Dialogue[0];
			displayText ();
        }
        else {
            if (isCreated) {
                Destroy(tb, 0);
                isCreated = false;
            }
        }
    }

    void displayText() {
		if (Input.GetKeyUp (KeyCode.Return)) {
			isUp = true;
			isDown = false;
		} 
		else if (Input.GetKeyDown (KeyCode.Return) && isUp) {
			isDown = true;
			isUp = false;
			curFrame++;
			play.GetComponent<Player>().CanMove = false; 
		}

		if (curFrame > dialogueSize - 1) {
			curFrame = 0;
			play.GetComponent<Player>().CanMove = true;
		}
		tb.transform.GetChild (0).GetComponent<Text> ().text = Dialogue [curFrame];
		Debug.Log (Dialogue [curFrame]);
    }
}
