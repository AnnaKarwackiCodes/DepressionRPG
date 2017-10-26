using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public Sprite normalSprite;
    public Sprite withLight;
    public GameObject play;
    private float playerSpeed;
    private int damnage;
    private bool inInteraction;
	protected bool canMove = true;
    private char CollisionKey;
    private char lastKey;
	private GameObject gm;

    // Use this for initialization
    void Start () {
        playerSpeed = 3;
        inInteraction = false;
		gm = GameObject.Find ("GameManager");
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
	}

    void Movement() { //WORKS BETTER BUT STILL NEEDS TO BE IMPROVED
		if (canMove) {
			//moving up
			if (Input.GetKey(KeyCode.W)) {
				if (CollisionKey != 'W')
				{
					play.transform.Translate(Vector2.up * playerSpeed * Time.deltaTime);
				}
                lastKey = 'W';
			}
			//moving down
			else if (Input.GetKey(KeyCode.S))
			{
				if (CollisionKey != 'S')
				{
					play.transform.Translate(Vector2.down * playerSpeed * Time.deltaTime);
				}
                lastKey = 'S';
			}
			//moving left
			if (Input.GetKey(KeyCode.A))
			{
				if (CollisionKey !='A')
				{
					play.transform.Translate(Vector2.left * playerSpeed * Time.deltaTime);
				}
                lastKey = 'A';
			}
			//moving right
			if (Input.GetKey(KeyCode.D))
			{
                if (CollisionKey != 'D')
				{
					play.transform.Translate(Vector2.right * playerSpeed * Time.deltaTime);
				}
                lastKey = 'D';
			}
		}
    }

    //collison stuff!
    public void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.gameObject.tag == "Enviroment" || collision.gameObject.tag == "NPC") {
			CollisionKey = lastKey;
			Debug.Log ("hit");
		} 
		else if (collision.gameObject.tag == "Overthinking") {
			gm.GetComponent<GameManager> ().NumToSpawn = 20;
			gm.GetComponent<GameManager> ().Trigger = true;
		}
		else if (collision.gameObject.tag == "ot pre") {
			//collision.GetComponent<Overthinking> ().spawnOne ();
		}
		else if(collision.gameObject.tag == "dog"){
			Debug.Log ("Found Dog");
			GlobalStuff.HaveQuestItem = true;
		}
        else {
            Debug.Log("Collision");
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        CollisionKey = ' ';
    }

	//get set
	public bool CanMove{
		get{ 
			return canMove;
		}
		set{ 
			this.canMove = value;
		}
	}

    public bool InInteraction {
        get {
            return inInteraction;
        }
        set
        {
            inInteraction = value;
        }
    }
}
