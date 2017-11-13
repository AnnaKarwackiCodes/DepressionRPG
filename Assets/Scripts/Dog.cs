using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour {
    private bool follow;
    private GameObject play;
	private bool moveUp;
	private bool moveDown;
	private bool moveLeft;
	private bool moveRight;
	private float time;
	// Use this for initialization
	void Start () {
        //follow = false;
        play = GameObject.Find("Player");
		time = .5f;
	}
	
	// Update is called once per frame
	void Update () {
        withinRange();
        if (follow && GlobalStuff.HaveQuestItem) 
        {
			if (time < 0) {
				if (moveUp) {
					transform.Translate(Vector2.up * 3 * Time.deltaTime);
					moveUp = false;
				}
				if (moveDown) {
					transform.Translate(Vector2.down * 3 * Time.deltaTime);
					moveDown = false;
				}
				if (moveLeft) {
					transform.Translate(Vector2.left * 3 * Time.deltaTime);
					moveLeft = false;
				}
				if (moveRight) {
					transform.Translate(Vector2.right * 3 * Time.deltaTime);
					moveRight = false;
				}
				time = .5f;
			}
			time -= Time.deltaTime;
        }
	}

    void withinRange()
    {
        float distance = Mathf.Pow(play.transform.position.x - transform.position.x, 2) + Mathf.Pow(play.transform.position.y - transform.position.y, 2);
        distance = Mathf.Sqrt(distance);
        if(distance < 3)
        {
            follow = true;
            GlobalStuff.HaveQuestItem = true;
        }
    }

    public bool Follow
    {
        get { return follow; }
        set { follow = value; }
    }

	public bool MoveUp
	{
		get { return moveUp; }
		set { moveUp = value; }
	}

	public bool MoveDown
	{
		get { return moveDown; }
		set { moveDown = value; }
	}

	public bool MoveLeft
	{
		get { return moveLeft; }
		set { moveLeft = value; }
	}
	public bool MoveRight
	{
		get { return moveRight; }
		set { moveRight = value; }
	}
}
