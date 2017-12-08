using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour {
    private bool follow;
    private GameObject play;
    private Animator anime;
    // Use this for initialization
    void Start () {
        //follow = false;
        play = GameObject.Find("Player");
        anime = this.GetComponent<Animator>();
        anime.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        withinRange();
        if (follow && GlobalStuff.HaveQuestItem && !GlobalStuff.IsPaused) 
        {
            float distance = Mathf.Pow(play.transform.position.x - transform.position.x, 2) + Mathf.Pow(play.transform.position.y - transform.position.y, 2);
            distance = Mathf.Sqrt(distance);
            if (distance < 3)
            {
                if (play.GetComponent<Player>().Direct != 4)
                {
                    anime.enabled = true;
                    anime.SetInteger("Direction", play.GetComponent<Player>().Direct);
                }
                else
                {
                    anime.enabled = false;
                }
                transform.position = Vector3.MoveTowards(transform.position, play.GetComponent<Player>().FollowBuff, 4 * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.down * 0 * Time.deltaTime);
                anime.enabled = false;
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
            if (GlobalStuff.EntriesUnlocked == 5)
            {
                GlobalStuff.GetAlert = true;
            }
        }
    }

    public bool Follow
    {
        get { return follow; }
        set { follow = value; }
    }

   
}
