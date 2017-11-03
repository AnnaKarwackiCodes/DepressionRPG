using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wizard : MonoBehaviour {
	public string Name;
	public Sprite look;
	public string[] Dialogue;
	public string[] Dialogue2;
	public GameObject textbox;

	private GameObject can;
	private GameObject play;
	private int dialogueSize;
	private GameObject gm;
	private int curFrame;
	private GameObject tb;
	private bool isCreated;

	private bool isUp = true;
	private bool isDown = false;
	// Use this for initialization
	void Start () {
		can = GameObject.Find ("Canvas");
		play = GameObject.Find ("Player");
		gm = GameObject.Find ("GameManager");
		curFrame = 0;
		isCreated = false;

		if (gm.GetComponent<GameManager> ().RoomName == "Area 3") {
			dialogueSize = Dialogue.Length;
		}
		else if (gm.GetComponent<GameManager> ().RoomName == "Wizard house") { //name tbd
			dialogueSize = Dialogue2.Length;
			GlobalStuff.WizFinished = false;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (gm.GetComponent<GameManager> ().RoomName == "Area 3") {
			if (GlobalStuff.WizFinished == false) {
				MoveCharacter ();    
			}
			else {
				moveOff ();
				GlobalStuff.TalkToWiz = true;
			}
		}
		else if (gm.GetComponent<GameManager> ().RoomName == "Wizard house") { //name tbd
			atHouse();
			if (GlobalStuff.WizFinished) {
				GlobalStuff.UseSpell = true;
			}
		}
	}

	void MoveCharacter(){
		float distance = Mathf.Pow (play.transform.localPosition.x - transform.localPosition.x, 2) + Mathf.Pow (play.transform.localPosition.y - transform.localPosition.y, 2);
		distance = Mathf.Sqrt (distance);
		if (distance > 3) {
			transform.Translate ((Vector2.right * 3 * Time.deltaTime));

		} else {
			transform.Translate ((Vector2.left * 0 * Time.deltaTime));
			if (!GlobalStuff.WizFinished) {
				if (isCreated == false)
				{
					tb = Instantiate(textbox, new Vector2(Screen.width / 2, Screen.height / 6f), new Quaternion(0, 0, 0, 0), can.transform);
					isCreated = true;
				}
				tb.transform.GetChild(1).GetComponent<Image>().sprite = look;
				tb.transform.GetChild(0).GetComponent<Text>().text = Dialogue[curFrame];
				tb.transform.GetChild(2).GetComponent<Text>().text = Name;
				displayText();
			}
		}
	}

	void moveOff()
	{
		transform.Translate((Vector2.left * 3 * Time.deltaTime));
		play.GetComponent<Player>().CanMove = true;
	} 

	void displayText()
	{

		if (Input.GetKeyUp(KeyCode.E))
		{
			isUp = true;
			isDown = false;
		}
		else if (Input.GetKeyDown(KeyCode.E) && isUp)
		{
			isDown = true;
			isUp = false;
			curFrame++;
			play.GetComponent<Player> ().CanMove = false;
		}

		if (curFrame >= dialogueSize)
		{
			if (isCreated)
			{
				Destroy(tb, 0);
				isCreated = false;
				//finished = true;
				GlobalStuff.TalkToWiz = true;
				GlobalStuff.WizFinished = true;
				play.GetComponent<Player>().CanMove = true;
				curFrame = 0;
			}
		}
	}

	void atHouse(){
		float distance = Mathf.Pow(play.transform.position.x - transform.position.x, 2) + Mathf.Pow(play.transform.position.y - transform.position.y, 2);
		distance = Mathf.Sqrt(distance);
		if (distance < 3)
		{
			if (isCreated == false) {
				tb = Instantiate(textbox, new Vector2(Screen.width/2,Screen.height/6f), new Quaternion(0,0,0,0), can.transform);
				isCreated = true;

				play.GetComponent<Player>().InInteraction = true;
				tb.transform.GetChild(1).GetComponent<Image>().sprite = look;

				tb.transform.GetChild(2).GetComponent<Text>().text = Name;
			}
			tb.transform.GetChild(0).GetComponent<Text>().text = Dialogue2[curFrame];
			displayText ();
		}
		else {
			if (isCreated) {
				Destroy(tb, 0);
				isCreated = false;
				play.GetComponent<Player>().InInteraction = false;
			}

		}
	}
}
