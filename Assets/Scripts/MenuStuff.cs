using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuStuff : MonoBehaviour {
    public GameObject[] buttons;
    public GameObject Title;
    public GameObject controls;
    public GameObject can;

    private bool isDownW = false;
    private bool isUpW = true;

    private bool isDownS = false;
    private bool isUpS = true;

    private int curButton = 0;

    private bool created = false;
    private GameObject con;
    private bool control = false;
	// Use this for initialization
	void Start () {
        //setting up the global shit
        GlobalStuff.setBaddieOne(3);
        GlobalStuff.WasInBattle = false;
        GlobalStuff.Aniexty = true;
        GlobalStuff.AnxTalk = 0;
        GlobalStuff.KindFinished = false;

        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < 2; i++)
        {
            if (i == curButton)
            {
                buttons[i].GetComponent<Button>().image.color = Color.red;
            }
            else
            {
                buttons[i].GetComponent<Button>().image.color = Color.white;
            }
        }
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
            curButton--;
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
        if ((Input.GetKeyDown(KeyCode.E)||Input.GetKeyDown(KeyCode.Return)) && curButton == 0 && !control) {
            //SceneManager.LoadScene("Area 1", LoadSceneMode.Single);
            viewControls();
        }
        else if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return)){
            SceneManager.LoadScene("Area 1", LoadSceneMode.Single);
        }
    }

    void viewControls()
    {
        control = true;
        Title.SetActive(false);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }

        if (!created)
        {
            con = Instantiate(controls, can.transform);
            created = true;
        }
    }
}
