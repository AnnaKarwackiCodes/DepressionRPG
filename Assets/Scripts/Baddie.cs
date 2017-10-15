using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Baddie : MonoBehaviour {
    public int maxHealth;
    public string name;
    public int attackDamage;
    public Sprite look;
    public bool isDead = false;
    private GameObject play;
    public int BattleType;
    public int pos;

	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().sprite = look;
        play = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (!GlobalStuff.getBaddie(pos))
        {
            //enabled = false;
            Destroy(this.gameObject);
        }
        if (GlobalStuff.getBaddie(pos)) {
             WithInDistance();
        }
	}

    public void WithInDistance()
    {
        float distance = Mathf.Pow(play.transform.position.x - transform.position.x, 2) + Mathf.Pow(play.transform.position.y - transform.position.y, 2);
        distance = Mathf.Sqrt(distance);

        if (distance < 2) {
            PlayerPrefs.SetInt("BattleType", BattleType);
            GlobalStuff.PrevPos = play.transform.position;
            GlobalStuff.WasInBattle = true;
            GlobalStuff.CurFight = pos;
            SceneManager.LoadScene("BattleScene", LoadSceneMode.Single);
        }
    }
}
