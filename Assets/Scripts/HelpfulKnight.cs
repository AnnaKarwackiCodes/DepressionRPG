using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpfulKnight : MonoBehaviour {
    public string Name;
    public Sprite look;
    public string[] Dialogue;
    public GameObject textbox;
	private GameObject can;
    private GameObject play;
    private int dialogueSize;
    private bool isCreated = false;
    private GameObject tb;
    private string[] garbage;

    //text stuff
    private int curFrame = 0;
    private bool isUp = true;
    private bool isDown = false;

	private 
    // Use this for initialization
    void Start () {
        GetComponent<SpriteRenderer>().sprite = look;
        dialogueSize = Dialogue.Length;
		play = GameObject.Find ("Player");
		can = GameObject.Find ("Canvas");
    }
	
	// Update is called once per frame
	void Update () {
		moveCharacter ();
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

	void  moveCharacter(){
		Debug.Log ("moving");
		float distance = Mathf.Pow (play.transform.localPosition.x - transform.localPosition.x, 2) + Mathf.Pow (play.transform.localPosition.y - transform.localPosition.y, 2);
		distance = Mathf.Sqrt (distance);
		Debug.Log ("distance" + distance);
		//Debug.Log ("this pos" +transform.position);
		Debug.Log ("play pos" + play.transform.localPosition);

		if (distance > 3) {
			transform.Translate ((Vector2.left * 3 * Time.deltaTime));
			WithinRange ();

		} else {
			Debug.Log ("please be here");
			transform.Translate ((Vector2.left * 0 * Time.deltaTime));
		}
	}

	void WithinRange(){
		float distance = Mathf.Pow(play.transform.position.x - transform.position.x, 2) + Mathf.Pow(play.transform.position.y - transform.position.y, 2);
		distance = Mathf.Sqrt(distance);

		if (distance < 3)
		{
			if (isCreated == false) {
				tb = Instantiate(textbox, new Vector2(Screen.width/2,Screen.height/6f), new Quaternion(0,0,0,0), can.transform);
				isCreated = true;
				GlobalStuff.AnxTalk++;
			}
			tb.transform.GetChild(1).GetComponent<Image>().sprite = look;
			if (GlobalStuff.Aniexty == true)
			{
				//gibberish
				tb.transform.GetChild(0).GetComponent<Text>().text = "sdasheabfdcb";
				tb.transform.GetChild(2).GetComponent<Text>().text = "adnlsak";
			}
			else {
				tb.transform.GetChild(0).GetComponent<Text>().text = Dialogue[0];
				tb.transform.GetChild(2).GetComponent<Text>().text = Name;
			}
			displayText ();
		}
		else {
			if (isCreated) {
				Destroy(tb, 0);
				isCreated = false;
			}
		}
	}
}
