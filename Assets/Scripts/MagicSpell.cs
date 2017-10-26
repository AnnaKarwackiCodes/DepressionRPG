using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicSpell : MonoBehaviour {
	public Sprite canUse;
	public Sprite noUse;
	public GameObject[] charges;

	private int full;
	private int cur;
	private float chargeTime;
	private float time;
	private bool isUp = true;
	private bool isDown = false;
	private GameObject gm;

	// Use this for initialization
	void Start () {
		full = charges.Length;
		cur = full;
		chargeTime = 1f;
		time = chargeTime;
		gm = GameObject.Find ("GameManager");
	}
	
	// Update is called once per frame
	void Update () {
		if (cur == full) {
			useAttack ();
		}
		else {
			time -= Time.deltaTime;
			if (time <= 0) {
				charges [cur].GetComponent<Image> ().sprite = canUse;
				cur++;
				time = chargeTime;
			}
		}
	}

	void useAttack(){
		if (Input.GetKeyUp(KeyCode.Return))
		{
			isUp = true;
			isDown = false;
		}
		else if (Input.GetKeyDown(KeyCode.Return) && isUp)
		{
			isDown = true;
			isUp = false;
			cur = 0;
			gm.GetComponent<GameManager> ().DestroyBoxes ();
			for (int i = 0; i < full; i++) {
				charges [i].GetComponent<Image> ().sprite = noUse;
			}
		}
	}
}
