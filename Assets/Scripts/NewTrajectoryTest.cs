using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTrajectoryTest : MonoBehaviour {

    public Transform target;
    public int velocity = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Sets change in mouses x axis value to xAxis variable
        float xAxis = Input.GetAxis("Mouse Y");

        //Sets change in translation if change was less than 0 
        if (xAxis > 0)
        {
            transform.RotateAround(target.position, Vector3.down, velocity / 4);
        }

        //Sets change in translation if change was more than 0
        if (xAxis < 0)
        {
            transform.RotateAround(target.position, Vector3.up, velocity / 4);
        }
    }
}
