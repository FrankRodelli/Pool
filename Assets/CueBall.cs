using UnityEngine;
using System.Collections;

public class CueBall : MonoBehaviour {

	Vector3 initPosition;

	// Use this for initialization
	void Start () {

		initPosition = transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {

		//Resets ball to initial location of it goes into a pocket 
		var ballPositionX = transform.position.x;
		var ballPositionZ = transform.position.z;
		if (ballPositionX > 3.80 || ballPositionX < -3.80) {
			transform.position = initPosition;
			print ("You suck ass dude");
		
		}
	}
}
