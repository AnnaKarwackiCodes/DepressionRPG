using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStuff : MonoBehaviour {
    public GameObject[] buttons;

    private bool isDownW = false;
    private bool isUpW = true;

    private bool isDownS = false;
    private bool isUpS = true;

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
        //W input
        if (Input.GetKeyUp(KeyCode.W))
        {
            isUpW = true;
            isDownW = false;
        }
        else if (Input.GetKeyDown(KeyCode.W) && isUpW == true) {
            isDownW = true;
            isUpW = false;
            curButton++;
            if (curButton < 0)
            {
                curButton = 1;
            }
        }
        //S input
        if (Input.GetKeyUp(KeyCode.S))
        {
            isUpS = true;
            isDownS = false;
        }
        else if (Input.GetKeyDown(KeyCode.S) && isUpS == true)
        {
            isDownS = true;
            isUpS = false;
            curButton++;
            if (curButton > 1)
            {
                curButton = 0;
            }
        }
        Debug.Log(curButton);
        if (Input.GetKeyDown(KeyCode.Return) && curButton == 0) {
            SceneManager.LoadScene("Area 1", LoadSceneMode.Single);
        }
    }

}
