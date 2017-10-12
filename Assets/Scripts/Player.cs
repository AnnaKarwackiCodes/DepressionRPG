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
        //moving up
        if (Input.GetKey(KeyCode.W)) {
            if (isColliding == false)
            {
                play.transform.Translate(Vector2.up * playerSpeed * Time.deltaTime);
            }
            else {
                play.transform.Translate(-Vector2.up * playerSpeed * Time.deltaTime);
            }
            
        }
        //moving down
        else if (Input.GetKey(KeyCode.S))
        {
            if (isColliding == false)
            {
                play.transform.Translate(Vector2.down * playerSpeed * Time.deltaTime);
            }
            else
            {
                play.transform.Translate(-Vector2.down * playerSpeed * Time.deltaTime);
            }
        }
        //moving left
        if (Input.GetKey(KeyCode.A))
        {
            if (isColliding == false)
            {
                play.transform.Translate(Vector2.left * playerSpeed * Time.deltaTime);
            }
            else
            {
                play.transform.Translate(-Vector2.left * playerSpeed * Time.deltaTime);
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
                play.transform.Translate(-Vector2.right * playerSpeed * Time.deltaTime);
            }
        }
    }

    //collison stuff!
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enviroment" || collision.gameObject.tag == "NPC")
        {
            isColliding = true;

        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        isColliding = false;
    }
}
