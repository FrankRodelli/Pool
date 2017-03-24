using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Sets change in mouses x axis value to xAxis variable
        float xAxis = Input.GetAxis("Mouse X");

        //Sets cueball to variable
        GameObject cue = GameObject.Find("cueball");

        //Gets vector3 of cueball game object
        Vector3 objectVector3 = cue.transform.position;

        //Sets change in translation if change was less than 0 
        if(xAxis > 0)
        {
            transform.RotateAround(objectVector3, Vector3.up, 10);
        }
        
        //Sets change in translation if change was more than 0
        if(xAxis <0)
        {
            transform.RotateAround(objectVector3, Vector3.down, 10);
        }

        
	}
}
