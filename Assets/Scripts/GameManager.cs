using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public GameObject textbox;
    public GameObject player;
    public GameObject[] baddies;
	public bool forTesting;
	public GameObject HelpfulKnight;
	public GameObject Wizard;
    public string RoomName;
	public GameObject can;
    public string[] negthoughts;
    public GameObject dog;
    public GameObject overlay;

	private GameObject hk;
	private GameObject wiz;
	private bool spawn = false;

	public GameObject magic;

	private GameObject tb;
	private int numToSpawn;
	private int numOfSpawn;
	private GameObject[] boxes;
	private float time;
	private bool trigger;
	private GameObject mg;
	private bool iconCreate;
    private int spawnNum;
    private GameObject doggo;

	// Use this for initialization
	void Start () {
        //GlobalStuff.Aniexty = forTesting;

        //overlay.transform.position = new Vector3(overlay.transform.position.x, overlay.transform.position.y, -100);
        if(RoomName =="Area 1")
        {
            if (GlobalStuff.WasInBattle)
            {
                Respawn();
                GlobalStuff.WasInBattle = false;
            }
            if (GlobalStuff.HaveQuestItem)
            {
                doggo = Instantiate(dog, new Vector3(player.transform.position.x, player.transform.position.y - 2.5f, 0), new Quaternion(0, 0, 0, 0));
                GlobalStuff.HaveQuestItem = true;
                doggo.GetComponent<Dog>().Follow = true;
            }            
        }
        if(RoomName == "Area 2")
        {
            if (GlobalStuff.HaveQuestItem)
            {
                doggo = Instantiate(dog, new Vector3(player.transform.position.x + 1.5f, player.transform.position.y, 0), new Quaternion(0, 0, 0, 0));
                GlobalStuff.HaveQuestItem = true;
                doggo.GetComponent<Dog>().Follow = true;
            }
        }
		if (RoomName == "Area 3") {
			boxes = new GameObject[40];	
			numToSpawn = 5;
			numOfSpawn = 0;
			time = 1.5f;
			trigger = false;
            spawnNum = 1;
		}
        if(RoomName == "Crossroads")
        {
			player.GetComponent<Animator> ().enabled = true;
			player.GetComponent<Animator> ().SetInteger ("Direction", 2);
            if (GlobalStuff.HaveQuestItem)
            {
                doggo = Instantiate(dog, new Vector3(player.transform.position.x, player.transform.position.y-2.5f, 0), new Quaternion(0, 0, 0, 0));
                GlobalStuff.HaveQuestItem = true;
                doggo.GetComponent<Dog>().Follow = true;
            }
        }
        if(RoomName =="Wizard house")
        {
            if (GlobalStuff.HaveQuestItem)
            {
                doggo = Instantiate(dog, new Vector3(player.transform.position.x + 1, player.transform.position.y, 0), new Quaternion(0, 0, 0, 0));
                doggo.GetComponent<Dog>().Follow = true;
            }
        }
		iconCreate = false;
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

					if (distance > 9) {
						Destroy (hk, 0);
					}
				}
			}
            
		} else if (RoomName == "Area 2") {
			if (GlobalStuff.KindFinished) {
				if (spawn == false) {
					hk = Instantiate (HelpfulKnight, new Vector3 (-3, 2, 0), new Quaternion (0, 0, 0, 0));
					spawn = true;
				}
			}

		} else if (RoomName == "Area 3") {
			if (trigger || GlobalStuff.UseSpell) {
				numToSpawn = 20;
				spawnTextBoxes ();
				time -= Time.deltaTime;
			}
			if (numOfSpawn >= numToSpawn && !GlobalStuff.UseSpell) {
				DestroyBoxes (); // add delay later
				player.transform.position = new Vector2 (-12.9f, -.48f);
				player.GetComponent<Player> ().SpriteDir = 2;
				//spawn in wizard to talk
				spawnWizard ();
			}
			if(numOfSpawn >= NumToSpawn && GlobalStuff.UseSpell){
				DestroyBoxes ();
				player.transform.position = new Vector2 (-12.9f, -.48f);
				player.GetComponent<Player> ().SpriteDir = 2;
				time = 3f;

			}
		} else if (RoomName == "Wizard house") {
			if (GlobalStuff.TalkToWiz) {
				if (spawn == false) {
					wiz = Instantiate (Wizard, new Vector3 (player.transform.position.x - 4, player.transform.position.y, 0), new Quaternion (0, 0, 0, 0));
					spawn = true;
				}
			}
		}

		if (GlobalStuff.UseSpell) {
			if (!iconCreate) {
				mg = Instantiate (magic, new Vector2 (300, Screen.height - 50), new Quaternion (0, 0, 0, 0), can.transform);
				mg.transform.SetAsLastSibling ();
				iconCreate = true;
			}
		}
	}
    //respawn into proper place 
    private void Respawn() {
        player.transform.position = GlobalStuff.PrevPos;
    }

    private void spawnKnight() {
		if (spawn == false) {
			hk = Instantiate (HelpfulKnight, new Vector3 (player.transform.position.x, player.transform.position.y + 6, 0), new Quaternion (0, 0, 0, 0));
			spawn = true;
			//player.GetComponent<Player> ().CanMove = false;
		}
    }

	private void spawnTextBoxes(){
        //if (numOfSpawn < numToSpawn && time <= 0) {
        if (time <= 0)
        {
            for (int i = 0; i < spawnNum; i++)
            {
                tb = Instantiate(textbox, new Vector2(Random.Range((20), (Screen.width - 20)), Random.Range((20), (Screen.height - 20))), new Quaternion(0, 0, 0, 0), can.transform);
                tb.transform.GetChild(0).GetComponent<Text>().text = negthoughts[Random.Range(0, negthoughts.Length - 1)];
                boxes[numOfSpawn] = tb;
                numOfSpawn++;
                tb.transform.SetAsFirstSibling();
            }
            spawnNum++;
            time = 1.5f;
        }
	}

	public void DestroyBoxes(){
		for (int i = 0; i < numOfSpawn; i++) {
			Destroy (boxes [i], 0);
		}
		numOfSpawn = 0;
        spawnNum = 1;
		trigger = false;
	}

	private void spawnWizard(){
		if (spawn == false) {
			wiz = Instantiate (Wizard, new Vector3 (player.transform.position.x - 15, player.transform.position.y, 0), new Quaternion (0, 0, 0, 0));
			spawn = true;
			numOfSpawn = 0;
			player.GetComponent<Player>().CanMove = false;
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
