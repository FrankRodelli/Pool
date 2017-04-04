using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueStick : MonoBehaviour {

    public GameObject target;
    public Vector3 relativeDistance = new Vector3(0,0,.94f);
    public int velocity;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


    }

    private void LateUpdate()
    {
        //Hides cuestick if ball is moving. Need to implement delay for stick hitting ball
        if (GameObject.Find("traj").GetComponent<Trajectory>().isMoving)
        {
            //Hides marker when ball is moving 
            GetComponent<Renderer>().enabled = false;
        }
        else
        {
            GetComponent<Renderer>().enabled = true;
        }
        
        MoveCueStick();
        
    }

    void MoveCueStick()
    {
        float power = GameObject.Find("cueball").GetComponent<CueBall>().multiplier;
        //Updates transform based on cueball location
        transform.position = (target.transform.position + relativeDistance);
        transform.position = new Vector3(transform.position.x, transform.position.y,transform.position.z +.94f + power/6);

        //Sets velocity based on whether mouse button is down or not
        if (GameObject.Find("traj").GetComponent<Trajectory>().isDown)
        {
            velocity = 0;
        }
        else
        {
            velocity = 10;
        }

        //Sets change in mouses x axis value to xAxis variable
        float xAxis = Input.GetAxis("Mouse Y");

        //Sets change in translation if change was less than 0 
        if (xAxis > 0)
        {
            transform.RotateAround(target.transform.position, Vector3.down, velocity / 6);
        }

        //Sets change in translation if change was more than 0
        if (xAxis < 0)
        {
            transform.RotateAround(target.transform.position, Vector3.up, velocity / 6);
        }

        //Reset relative position
        relativeDistance = transform.position - target.transform.position;
        relativeDistance = new Vector3(relativeDistance.x, relativeDistance.y, relativeDistance.z - .94f - power/6);
    }
}
