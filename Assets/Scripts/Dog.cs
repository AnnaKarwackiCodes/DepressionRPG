using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour {
    private bool follow;
    private GameObject play;
	// Use this for initialization
	void Start () {
        //follow = false;
        play = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        withinRange();
        if (follow && GlobalStuff.HaveQuestItem) 
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector2.up * 3 * Time.deltaTime);
            }
            //moving down
            else if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector2.down * 3 * Time.deltaTime);
            }
            //moving left
            else if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector2.left * 3 * Time.deltaTime);
            }
            //moving right
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector2.right * 3 * Time.deltaTime);
            }
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
}
