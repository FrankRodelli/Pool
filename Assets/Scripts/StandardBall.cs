using UnityEngine;
using System.Collections;

public class StandardBall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//Finds location of ball and deletes gameobject if out of range
		if (transform.position.x > 3.80 || transform.position.x < -3.80) {
            
			Destroy (gameObject);

            //Changes ballcount when ball is destroyed
            GameObject.Find("Plane").GetComponent<FreeMode>().numberOfBalls--;
		}
	
	}
}
