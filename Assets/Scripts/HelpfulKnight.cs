using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HelpfulKnight : MonoBehaviour {
    public string Name;
    public Sprite look;
    public string[] Dialogue;
    public string[] Dialogue2;
    public string[] Dialogue3;
    public string[] Dialogue4;
    public GameObject textbox;

	private GameObject can;
    private GameObject play;
    private int dialogueSize;
    private bool isCreated = false;
    private GameObject tb;
    private string[] garbage;
    private GameObject gm;
    private int whichDialogue;

    //text stuff
    private int curFrame = 0;
    private bool isUp = true;
    private bool isDown = false;
    private bool finished = false;
    private float time = 2f;
    private float time2 = 3f;

	private 
    // Use this for initialization
    void Start () {
        GetComponent<SpriteRenderer>().sprite = look;
        dialogueSize = Dialogue.Length;
		play = GameObject.Find ("Player");
		can = GameObject.Find ("Canvas");
        gm = GameObject.Find("GameManager");
        whichDialogue = 0;

        if (gm.GetComponent<GameManager>().RoomName == "Area 2")
        {
            whichDialogue = 1;
            dialogueSize = Dialogue2.Length;
            Debug.Log("fuckers" + dialogueSize);    
            play.GetComponent<Player>().CanMove = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (gm.GetComponent<GameManager>().RoomName == "Area 1")
        {
            moveCharacter();
        }
        else if (gm.GetComponent<GameManager>().RoomName == "Area 2") {
            MoveWithPlayer();
        }
	}
    //show the text
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
        }
        
        if (curFrame >= dialogueSize)
        {
            if (isCreated)
            {
                Debug.Log("i want to die " + dialogueSize);
                Destroy(tb, 0);
                isCreated = false;
                finished = true;
                curFrame = 0;
                whichDialogue++;
                time = 2f;
            }
        }

        //tb.transform.GetChild(0).GetComponent<Text>().text = Dialogue[curFrame];
    }
//moving the character
	void  moveCharacter(){
		float distance = Mathf.Pow (play.transform.localPosition.x - transform.localPosition.x, 2) + Mathf.Pow (play.transform.localPosition.y - transform.localPosition.y, 2);
		distance = Mathf.Sqrt (distance);
        if (distance > 3) {
			transform.Translate ((Vector2.left * 3 * Time.deltaTime));

		} else {
			transform.Translate ((Vector2.left * 0 * Time.deltaTime));
            if (!finished) {
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

        if (finished) {
            transform.Translate((Vector2.right * 3 * Time.deltaTime));
            play.transform.Translate((Vector2.right * 3 * Time.deltaTime));
            time -= Time.deltaTime;
            if (time <= 0) {
                SceneManager.LoadScene("Area 2", LoadSceneMode.Single);
            }
        }
	}

    void MoveWithPlayer() {
        time -= Time.deltaTime;
        if(whichDialogue < 4)
        {
            if (time >= 0)
            {
                transform.Translate((Vector2.right * 3 * Time.deltaTime));
                play.transform.Translate((Vector2.right * 3 * Time.deltaTime));
            }
            else if ((time <= 0))
            {
                if (!isCreated)
                {
                    tb = Instantiate(textbox, new Vector2(Screen.width / 2, Screen.height / 6f), new Quaternion(0, 0, 0, 0), can.transform);
                    isCreated = true;
                }
                tb.transform.GetChild(1).GetComponent<Image>().sprite = look;
                tb.transform.GetChild(2).GetComponent<Text>().text = Name;
                if (whichDialogue == 1)
                {
                    tb.transform.GetChild(0).GetComponent<Text>().text = Dialogue2[curFrame];

                }
                else if (whichDialogue == 2)
                {
                    dialogueSize = Dialogue3.Length;
                    tb.transform.GetChild(0).GetComponent<Text>().text = Dialogue3[curFrame];
                }
                else if (whichDialogue == 3)
                {
                    dialogueSize = Dialogue4.Length;
                    tb.transform.GetChild(0).GetComponent<Text>().text = Dialogue4[curFrame];
                }
                displayText();
            }
        }
        else
        {
            time2 -= Time.deltaTime;
            if(time2 > 0)
            {
                transform.Translate((Vector2.right * 3 * Time.deltaTime));
            }
            else
            {
                transform.Translate((Vector2.right * 3 * Time.deltaTime));
                play.GetComponent<Player>().CanMove = true;
                GlobalStuff.Aniexty = false;
            }
        }

    }
}
