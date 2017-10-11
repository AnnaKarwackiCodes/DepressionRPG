using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStuff : MonoBehaviour {
    public GameObject[] buttons;

    private bool isDown = false;
    private bool isUp = false;

    private int curButton = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        keyboardInput();
	}

    //keyboard input
    void keyboardInput() {
        if (Input.GetKeyUp(KeyCode.W))
        {
            isUp = true;
            curButton++;
            if (curButton > buttons.Length) {
                curButton = buttons.Length;
            }
            Debug.Log(curButton);
        }
        else if (Input.GetKeyDown(KeyCode.W) && isUp == true) {
            isDown = true;
        }

        if (Input.GetKeyDown(KeyCode.Return)) {
            Debug.Log("I am here");
            SceneManager.LoadScene("Area 1", LoadSceneMode.Single);
        }
    }

}
