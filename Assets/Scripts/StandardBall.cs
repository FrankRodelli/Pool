﻿using UnityEngine;
using System.Collections;

public class StandardBall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//Finds location of ball and deletes gameobject if out of range
		if (transform.position.x > 3.80 || transform.position.x < -3.80) {

            string ballName = gameObject.transform.name;

			Destroy (gameObject);
		}
	
	}
}
