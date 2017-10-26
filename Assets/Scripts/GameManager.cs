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
	private GameObject hk;
	private bool spawn = false;
	// Use this for initialization
	void Start () {
		//GlobalStuff.Aniexty = forTesting;
        if (GlobalStuff.WasInBattle && RoomName == "Area 1")
        {
            Respawn();
            GlobalStuff.WasInBattle = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (RoomName == "Area 1") {
            //GlobalStuff.Aniexty = forTesting;
            if (GlobalStuff.Aniexty == true)
            {
                if (GlobalStuff.AnxTalk >= 3 && !player.GetComponent<Player>().InInteraction)
                {
                    player.GetComponent<Player>().CanMove = false;
                    //summon other knight
                    spawnKnight();
                    //set anxtalk to weird number
                    GlobalStuff.AnxTalk = -1;
                }
            }
            if (GlobalStuff.KindFinished)
            {
                GameObject temp = GameObject.FindGameObjectWithTag("Kind Knight");
                if ( temp != null)
                {
                    float distance = Mathf.Pow(player.transform.localPosition.x - hk.transform.localPosition.x, 2) + Mathf.Pow(player.transform.localPosition.y - hk.transform.localPosition.y, 2);
                    distance = Mathf.Sqrt(distance);

                    Debug.Log(distance);

                    if (distance > 9)
                    {
                        Destroy(hk, 0);
                    }
                }
            }
            
        }
        else if (RoomName == "Area 2") {

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


}
