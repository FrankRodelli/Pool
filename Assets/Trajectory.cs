using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour {

    public int velocity;
    public bool isDown;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        //Tests whether mousebutton is held down and 
        //Sets bool accordingly
        if (Input.GetMouseButtonDown(0))
        {
            isDown = true;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            isDown = false;
        }
        
        //Calls movetrajectory method
        moveTrajectory();
    }

    void moveTrajectory()
    {
        //Sets velocity based on whether mouse button is down or not
        if (isDown)
        {
            velocity = 0;
        }
        else
        {
            velocity = 10;
        }

        //Sets change in mouses x axis value to xAxis variable
        float xAxis = Input.GetAxis("Mouse X");

        //Sets cueball to variable
        GameObject cue = GameObject.Find("cueball");

        //Gets vector3 of cueball game object
        Vector3 objectVector3 = cue.transform.position;

        //Sets change in translation if change was less than 0 
        if (xAxis > 0)
        {
            transform.RotateAround(objectVector3, Vector3.up, velocity / 4);
        }

        //Sets change in translation if change was more than 0
        if (xAxis < 0)
        {
            transform.RotateAround(objectVector3, Vector3.down, velocity / 4);
        }
    }
}
