using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public Sprite normalSprite;
    public Sprite withLight;
    public GameObject play;
    private float playerSpeed;
    private int damnage;

	// Use this for initialization
	void Start () {
        playerSpeed = 3;
		
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
	}

    void Movement() {
        //moving up
        if (Input.GetKey(KeyCode.W)) {
            play.transform.Translate(Vector2.up * playerSpeed * Time.deltaTime);
            Debug.Log("i am here");
        }
        //moving down
        else if (Input.GetKey(KeyCode.S))
        {
            play.transform.Translate(Vector2.down * playerSpeed * Time.deltaTime);
        }
        //moving left
        if (Input.GetKey(KeyCode.A))
        {
            play.transform.Translate(Vector2.left * playerSpeed * Time.deltaTime);
        }
        //moving right
        if (Input.GetKey(KeyCode.D))
        {
            play.transform.Translate(Vector2.right * playerSpeed * Time.deltaTime);
        }
    }
}
