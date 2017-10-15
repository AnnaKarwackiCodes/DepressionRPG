using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public Sprite normalSprite;
    public Sprite withLight;
    public GameObject play;
    private float playerSpeed;
    private int damnage;
    private bool isColliding;
	protected bool canMove = true;
    protected string CollisionKey;

    // Use this for initialization
    void Start () {
        playerSpeed = 3;
        isColliding = false;
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
	}

    void Movement() {
		if (canMove) {
			//moving up
			if (Input.GetKey(KeyCode.W)) {
				if (CollisionKey != "W")
				{
					play.transform.Translate(Vector2.up * playerSpeed * Time.deltaTime);
				}

			}
			//moving down
			else if (Input.GetKey(KeyCode.S))
			{
				if (CollisionKey != "S")
				{
					play.transform.Translate(Vector2.down * playerSpeed * Time.deltaTime);
				}
			}
			//moving left
			if (Input.GetKey(KeyCode.A))
			{
				if (CollisionKey !="A")
				{
					play.transform.Translate(Vector2.left * playerSpeed * Time.deltaTime);
				}
			}
			//moving right
			if (Input.GetKey(KeyCode.D))
			{
				if (isColliding == false)
				{
					play.transform.Translate(Vector2.right * playerSpeed * Time.deltaTime);
				}
				else
				{
					play.transform.Translate(-Vector2.right * (playerSpeed + 3) * Time.deltaTime);
				}
			}
		}
    }

    //collison stuff!
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enviroment" || collision.gameObject.tag == "NPC")
        {
            isColliding = true;
            if (Input.GetKeyDown(KeyCode.A)) { CollisionKey = "A"; }
            if (Input.GetKeyDown(KeyCode.W)) { CollisionKey = "W"; }
            if (Input.GetKeyDown(KeyCode.S)) { CollisionKey = "S"; }
            if (Input.GetKeyDown(KeyCode.D)) { CollisionKey = "D"; }
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        isColliding = false;
        CollisionKey = "";
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
}
