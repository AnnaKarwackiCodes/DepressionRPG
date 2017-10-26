using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Overthinking : MonoBehaviour {
	public GameObject textbox;
	public GameObject can;
	public string thought;

	private GameObject tb;
	private bool isCreated;
	private GameObject gm;
	private GameObject play;
	private float time;
	// Use this for initialization
	void Start () {
		isCreated = false;
		gm = GameObject.Find ("GameManager");
		play = GameObject.Find ("Player");
		time = 1;
	}
	
	// Update is called once per frame
	void Update () {
		spawnOne ();
		if (isCreated) {
			time -= Time.deltaTime;
			if (time <= 0) {
				Destroy (tb, 0);
				isCreated = false;
				time = 1;
			}
		}
	}

	public void spawnOne(){
		
		float distance = Mathf.Pow (play.transform.localPosition.x - transform.localPosition.x, 2) + Mathf.Pow (play.transform.localPosition.y - transform.localPosition.y, 2);
		distance = Mathf.Sqrt (distance);
		if (distance < 1) {
			Debug.Log ("spawn");


		} 
	}

	public void OnTriggerEnter2D(Collider2D collision){
		Debug.Log ("dnfksdjngskj");
		if (collision.gameObject.tag == "Player") {
			if (isCreated == false)
			{
				tb = Instantiate(textbox, new Vector2(Screen.width / 2, Screen.height / 1.25f), new Quaternion(0, 0, 0, 0), can.transform);
				tb.transform.GetChild(0).GetComponent<Text>().text = thought;
				isCreated = true;
			}
			//Debug.Log ("dnfksdjngskj");
			//gm.GetComponent<GameManager> ().NumToSpawn++;
		}
	}

}
