using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour {
    private bool follow;
	// Use this for initialization
	void Start () {
        follow = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (follow)
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

    public bool Follow
    {
        get { return follow; }
        set { follow = value; }
    }
}
