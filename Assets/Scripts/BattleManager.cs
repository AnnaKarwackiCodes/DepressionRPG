using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log(PlayerPrefs.GetInt("BattleType"));
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return)) {
            GlobalStuff.changeBaddie(GlobalStuff.CurFight, false);
            SceneManager.LoadScene("Area 1", LoadSceneMode.Single);
        }
	}
}