using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EightBall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Restarts the game if 8ball goes out of pocket
        if (transform.position.x > 3.80 || transform.position.x < -3.80)
        {
            Application.LoadLevel("PoolTable");
        }

    }
}
