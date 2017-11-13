using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour {
    private float width;
    private float height;
    private GameObject player;
    private float playWidth;
    private float playHeight;
    private float playX;
    private float playY;
    private float myX;
    private float myY;

    public float mod;

	// Use this for initialization
	void Start () {
        width = this.GetComponent<SpriteRenderer>().bounds.size.x/2;
        height = this.GetComponent<SpriteRenderer>().bounds.size.y/2;
        player = GameObject.Find("Player");
        playWidth = player.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        playHeight = player.GetComponent<SpriteRenderer>().bounds.size.y/ 2;
        
    }
	
	// Update is called once per frame
	void Update () {
        playX = player.transform.position.x;
        playY = player.transform.position.y;

        myX = this.transform.position.x;
        myY = this.transform.position.y;
        if ((myX-width + mod) < (playX + playWidth) && (myX + width - mod) > (playX - playWidth) )
        {
            if ((myY - height + mod) < (playY - playHeight) && (myY + height - mod) > (playY - playHeight))
            {
                
            }
            else
            {
                player.GetComponent<Player>().Collision = ' ';
            }
        }
	}
}
