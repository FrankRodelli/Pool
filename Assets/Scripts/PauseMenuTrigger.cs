using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuTrigger : MonoBehaviour {

    public GameObject PM;
    public bool isPaused = false;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PM.activeSelf)
            {
                PM.SetActive(false);
                Cursor.visible = false;
                isPaused = false;
            }
            else{
                PM.SetActive(true);
                Cursor.visible = true;
                isPaused = true;
            }
        }
	}
}
