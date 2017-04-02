using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Menu : MonoBehaviour {
    NetworkManagerHUD hudManager;
    // Use this for initialization
    void Start () {
        hudManager = GameObject.Find("server").GetComponent<NetworkManagerHUD>();
        hudManager.showGUI = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void launchScene()
    {
        Application.LoadLevel("PoolTable");
    }

    public void exitGame()
    {

    }

    public void launchSettings()
    {

    }

    public void multiplayer()
    {
        if(hudManager.showGUI == true)
        {
            hudManager.showGUI = false;
        }
        else {
            hudManager.showGUI = true;
        }
    }
}
