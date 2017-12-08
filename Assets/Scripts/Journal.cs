using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journal : MonoBehaviour {
    public GameObject journal;
    private bool isCreated;
    private bool isActive;
	// Use this for initialization
	void Start () {
        isCreated = false;
        isActive = false;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OpenCloseJournal() {
        if (Input.GetKey(KeyCode.Return)) {
            isActive = !isActive;
            if (isActive)
            {
                if (!isCreated)
                {
                    //create it
                }
            }
        }
    }
}
