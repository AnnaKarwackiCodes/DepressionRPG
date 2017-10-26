using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject textbox;
    public GameObject player;
    public GameObject[] baddies;
	public bool forTesting;
	public GameObject HelpfulKnight;
    public string RoomName;
	public GameObject can;
	private GameObject hk;
	private bool spawn = false;

	private GameObject tb;
	private int numToSpawn;
	private int numOfSpawn;
	private GameObject[] boxes;
	private float time;
	private bool trigger;

	// Use this for initialization
	void Start () {
		//GlobalStuff.Aniexty = forTesting;
        if (GlobalStuff.WasInBattle && RoomName == "Area 1")
        {
            Respawn();
            GlobalStuff.WasInBattle = false;
        }
		if (RoomName == "Area 3") {
			boxes = new GameObject[20];	
			numToSpawn = 5;
			numOfSpawn = 0;
			time = .5f;
			trigger = false;
		}
    }
	
	// Update is called once per frame
	void Update () {
		if (RoomName == "Area 1") {
			//GlobalStuff.Aniexty = forTesting;
			if (GlobalStuff.Aniexty == true) {
				if (GlobalStuff.AnxTalk >= 3 && !player.GetComponent<Player> ().InInteraction) {
					player.GetComponent<Player> ().CanMove = false;
					//summon other knight
					spawnKnight ();
					//set anxtalk to weird number
					GlobalStuff.AnxTalk = -1;
				}
			}
			if (GlobalStuff.KindFinished) {
				GameObject temp = GameObject.FindGameObjectWithTag ("Kind Knight");
				if (temp != null) {
					float distance = Mathf.Pow (player.transform.localPosition.x - hk.transform.localPosition.x, 2) + Mathf.Pow (player.transform.localPosition.y - hk.transform.localPosition.y, 2);
					distance = Mathf.Sqrt (distance);

					Debug.Log (distance);

					if (distance > 9) {
						Destroy (hk, 0);
					}
				}
			}
            
		}
		else if (RoomName == "Area 2") {

		}
		else if (RoomName == "Area 3") {
			if (trigger) {
				spawnTextBoxes ();
				time -= Time.deltaTime;
			}
			if (numOfSpawn == numToSpawn) {
				DestroyBoxes (); // add delay later
				player.transform.position = new Vector2(-12.9f,-.48f);
				//spawn in wizard to talk
			}
		}
	}

    //respawn into proper place 
    private void Respawn() {
        player.transform.position = GlobalStuff.PrevPos;
    }

    private void spawnKnight() {
		if (spawn == false) {
			Debug.Log ("spawn");
			hk = Instantiate (HelpfulKnight, new Vector3 (player.transform.position.x + 15, player.transform.position.y, 0), new Quaternion (0, 0, 0, 0));
			spawn = true;
			//player.GetComponent<Player> ().CanMove = false;
		}
    }

	private void spawnTextBoxes(){
		if (numOfSpawn < numToSpawn && time <= 0) {
			Debug.Log ("I am here");
			tb = Instantiate(textbox, new Vector2(Random.Range((20), (Screen.width-20)), Random.Range((20), (Screen.height-20))), new Quaternion(0, 0, 0, 0), can.transform);
			boxes [numOfSpawn] = tb;
			Debug.Log(numOfSpawn);
			numOfSpawn++;
			time = .5f;
		}
	}

	private void DestroyBoxes(){
		for (int i = 0; i < numToSpawn; i++) {
			Destroy (boxes [i], 0);
		}
	}

	public int NumToSpawn{
		get{ return numToSpawn; }
		set{ numToSpawn = value; }
	}

	public bool Trigger{
		set{ trigger = value; }
	}
}
