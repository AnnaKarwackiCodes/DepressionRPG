using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour {
    public string Name;
    public Sprite look;
    public string[] Dialogue;
	public GameObject textbox;
	public GameObject play;
    private int dialogueSize;
    private bool isCreated = false;

	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().sprite = look;
        dialogueSize = Dialogue.Length;
        Debug.Log(dialogueSize);
    }
	
	// Update is called once per frame
	void Update () {
        WithinRange();
	}

	//if the player is within a distance of NPC show dialogue
	void WithinRange(){
        float distance = Mathf.Pow(play.transform.position.x - transform.position.x, 2) + Mathf.Pow(play.transform.position.y - transform.position.y, 2);
        distance = Mathf.Sqrt(distance);

        if (distance < 3)
        {
            //textbox.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -129, 0);
            if (isCreated == false) {
                Instantiate(textbox, new Vector3(0, -129, 0), new Quaternion(0, 0, 0, 0));
                isCreated = true;
            }
            textbox.transform.GetChild(0).GetComponent<Text>().text = Dialogue[0];
        }
        else {
            //textbox.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -400, 0);
            if (isCreated) {
                DestroyImmediate(textbox, true);
                isCreated = false;
            }
        }
    }

    void displayText() {

    }
}
