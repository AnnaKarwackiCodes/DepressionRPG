using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baddie : MonoBehaviour {
    public int maxHealth;
    public string name;
    public int attackDamage;
    public Sprite look;

	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().sprite = look;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
