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
    private Animator anime;
    public bool[] direction;
    public bool[] moveDir;
    private Stack<int> pressedKeys;

	public Sprite[] allDirections;

    // Use this for initialization
    void Start () {
        playerSpeed = 3;
        inInteraction = false;
		gm = GameObject.Find ("GameManager");
        anime = this.GetComponent<Animator>();
        direction = new bool[4];
        moveDir = new bool[4];
        pressedKeys = new Stack<int>();
        for(int i = 0; i < 4; i++)
        {
            direction[i] = false;
            moveDir[i] = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
	}

    void Movement() { //WORKS BETTER BUT STILL NEEDS TO BE IMPROVED
		if (canMove) {
			//moving up
			if (Input.GetKey(KeyCode.W) && !moveDir[0])
            {
                anime.enabled = true;
                anime.SetInteger("Direction", 0);
                play.transform.Translate(Vector2.up * playerSpeed * Time.deltaTime);
                direction[0] = true;
                pressedKeys.Push(0);

				if (GlobalStuff.HaveQuestItem) {
					GameObject.Find ("Dog").GetComponent<Dog> ().MoveUp = true;
				}
            }
			//moving down
			else if (Input.GetKey(KeyCode.S) && !moveDir[1])
			{
                anime.enabled = true;
                anime.SetInteger("Direction", 2);
                play.transform.Translate(Vector2.down * playerSpeed * Time.deltaTime);
                direction[1] = true;
                pressedKeys.Push(1);
				if (GlobalStuff.HaveQuestItem) {
					GameObject.Find ("Dog").GetComponent<Dog> ().MoveDown = true;
				}
            }
            //moving left
            if (Input.GetKey(KeyCode.A) && !moveDir[2])
			{
                anime.enabled = true;
                anime.SetInteger("Direction", 3);
                play.transform.Translate(Vector2.left * playerSpeed * Time.deltaTime);
                direction[2] = true;
                pressedKeys.Push(2);
				if (GlobalStuff.HaveQuestItem) {
					GameObject.Find ("Dog").GetComponent<Dog> ().MoveLeft = true;
				}
            }
			//moving right
			else if (Input.GetKey(KeyCode.D) && !moveDir[3])
			{
                anime.enabled = true;
                anime.SetInteger("Direction", 1);
                play.transform.Translate(Vector2.right * playerSpeed * Time.deltaTime);
                direction[3] = true;
                pressedKeys.Push(3);
				if (GlobalStuff.HaveQuestItem) {
					GameObject.Find ("Dog").GetComponent<Dog> ().MoveRight = true;
				}
            }
            if(!Input.GetKey(KeyCode.D)&& !Input.GetKey(KeyCode.W)&& !Input.GetKey(KeyCode.A)&& !Input.GetKey(KeyCode.S))
            {
                anime.enabled = false;
                
                for(int i =0; i < 4;i++)
                {
                    direction[i] = false;
                }
				GameObject.Find ("Dog").GetComponent<Dog> ().MoveUp = false;
				GameObject.Find ("Dog").GetComponent<Dog> ().MoveDown = false;
				GameObject.Find ("Dog").GetComponent<Dog> ().MoveLeft = false;
				GameObject.Find ("Dog").GetComponent<Dog> ().MoveRight = false;
            }

            

        }
        else
        {
            anime.enabled = false;
            for (int i = 0; i < 4; i++)
            {
                direction[i] = false;
            }
        }
    }
    
    //collison stuff!
    public void OnTriggerEnter2D(Collider2D collision)
    {

		if (collision.gameObject.tag == "Enviroment" || collision.gameObject.tag == "NPC") {
            //CollisionKey = lastKey;
            /*
            for(int i = 0; i < 4; i++)
            {
                moveDir[i] = direction[i];
            }
            */
            moveDir[pressedKeys.Pop()] = true;   
        } 
		else if (collision.gameObject.tag == "Overthinking") {
			gm.GetComponent<GameManager> ().NumToSpawn = 20;
			gm.GetComponent<GameManager> ().Trigger = true;
		}
		else if (collision.gameObject.tag == "ot pre") {
			//collision.GetComponent<Overthinking> ().spawnOne ();
		}
		else if(collision.gameObject.tag == "dog"){
            //collision.GetComponent<Dog>().Follow = true;
			//GlobalStuff.HaveQuestItem = true;
		}
        else {
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        CollisionKey = ' ';
        for (int i = 0; i < 4; i++)
        {
            moveDir[i] = false;
            direction[i] = false;
        }
        pressedKeys.Clear();
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
    public char Collision
    {
        get
        {
            return CollisionKey;
        }
        set
        {
            CollisionKey = value;
        }
    }

	public int SpriteDir{
		set{
			this.GetComponent<SpriteRenderer> ().sprite = allDirections [value];
		}
	}
}
