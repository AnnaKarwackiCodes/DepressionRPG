using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour {
    public string words;
    public string location;
    public GameObject textbox;
    public GameObject play;
    public GameObject can;
    public GameObject gameManager;
    private GameObject gm;
    private bool created = false;
    private GameObject tb;

    // Use this for initialization
    void Start() {
        gm = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update() {
        WithinRange();
    }

    void WithinRange()
    {
        float distance = Mathf.Pow(play.transform.position.x - transform.position.x, 2) + Mathf.Pow(play.transform.position.y - transform.position.y, 2);
        distance = Mathf.Sqrt(distance);

        if (distance < 3)
        {
            if (!created)
            {
                tb = Instantiate(textbox, new Vector2(Screen.width / 2, Screen.height / 6f), new Quaternion(0, 0, 0, 0), can.transform);
                created = true;
            }
            tb.transform.GetChild(0).GetComponent<Text>().text = words;
            moveToRoom();
        }
        else {
            if (created) {
                Destroy(tb, 0);
                created = false;
            }
        }
    }

    void moveToRoom() {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (gm.GetComponent<GameManager>().RoomName == "Area 1")
            {
                GlobalStuff.PrevPos = play.transform.position;
                GlobalStuff.WasInBattle = true;
            }
            SceneManager.LoadScene(location, LoadSceneMode.Single);
        }
    }
}
