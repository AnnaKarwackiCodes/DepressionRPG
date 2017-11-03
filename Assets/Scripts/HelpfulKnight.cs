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
    private Animator anime;

    //text stuff
    private int curFrame = 0;
    private bool isUp = true;
    private bool isDown = false;
    private bool finished = false;
    private float time = 2f;
    private float time2 = 3f;
    private bool interact = false;

	private 
    // Use this for initialization
    void Start () {
        GetComponent<SpriteRenderer>().sprite = look;
        dialogueSize = Dialogue.Length;
		play = GameObject.Find ("Player");
		can = GameObject.Find ("Canvas");
        gm = GameObject.Find("GameManager");
        whichDialogue = 0;
        anime = this.GetComponent<Animator>();

        if (gm.GetComponent<GameManager>().RoomName == "Area 2")
        {
            curFrame = 0;
            whichDialogue = 1;
            dialogueSize = Dialogue2.Length;
            
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (gm.GetComponent<GameManager>().RoomName == "Area 1")
        {
            if (GlobalStuff.KindFinished == false)
            {
                moveCharacter();    
            }
            else if (GlobalStuff.KindFinished)
            {
                moveOff();
            }
        }
        else if(gm.GetComponent<GameManager>().RoomName == "Area 2")
        {
            atFarm();
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
            //play.GetComponent<Player>().CanMove = false;
        }
        
        if (curFrame >= dialogueSize)
        {
            if (isCreated)
            {
                Destroy(tb, 0);
                isCreated = false;
                //finished = true;
                GlobalStuff.KindFinished = true;
                play.GetComponent<Player>().CanMove = true;
                curFrame = 0;
            }
        }

        //tb.transform.GetChild(0).GetComponent<Text>().text = Dialogue[curFrame];
    }
//moving the character
	void  moveCharacter(){
		float distance = Mathf.Pow (play.transform.localPosition.x - transform.localPosition.x, 2) + Mathf.Pow (play.transform.localPosition.y - transform.localPosition.y, 2);
		distance = Mathf.Sqrt (distance);
        if (distance > 3) {
            anime.SetInteger("Direction", 1);
			transform.Translate ((Vector2.left * 3 * Time.deltaTime));

		} else {
            anime.enabled = false;
			transform.Translate ((Vector2.left * 0 * Time.deltaTime));
            if (!GlobalStuff.KindFinished) {
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

    void atFarm()
    {
        anime.enabled = false;
        float distance = Mathf.Pow(play.transform.position.x - transform.position.x, 2) + Mathf.Pow(play.transform.position.y - transform.position.y, 2);
        distance = Mathf.Sqrt(distance);

        if (distance < 3)
        {
            if (isCreated == false)
            {
                tb = Instantiate(textbox, new Vector2(Screen.width / 2, Screen.height / 6f), new Quaternion(0, 0, 0, 0), can.transform);
                isCreated = true;
                play.GetComponent<Player>().InInteraction = true;
            }
            tb.transform.GetChild(1).GetComponent<Image>().sprite = look;
            tb.transform.GetChild(0).GetComponent<Text>().text = Dialogue2[curFrame];
            tb.transform.GetChild(2).GetComponent<Text>().text = Name;
            displayText();
        }
        else
        {
            if (isCreated)
            {
                Destroy(tb, 0);
                isCreated = false;
                play.GetComponent<Player>().InInteraction = false;
                curFrame = 0;
                GlobalStuff.Aniexty = false;
            }

        }
    }

    void moveOff()
    {
        transform.Translate((Vector2.right * 3 * Time.deltaTime));
        anime.enabled = true;
        anime.SetInteger("Direction", 0);
    } 

    public bool Finished
    {
        get
        {
            return finished;
        }
        set
        {
            finished = value;
        }
    }
}
