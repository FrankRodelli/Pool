using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{ 
    public int velocity;
    public bool isDown;
    public bool isMoving = false;
    public Vector3 lastPos = new Vector3(0, 0, 0);
    public int framecount = 0;
    Vector3 initPosition;
    GameObject cue;
    Quaternion rotation;

    // Use this for initialization
    void Start()
    {
        //Gets cueball game object
        cue = GameObject.Find("cueball");

        //Stores initial trajectory position
        initPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Adds 1 for time update is called
        framecount++;

        if(framecount == 3)
        {
            //Calls isMovingTest method
            isMovingTest();

            //Resets framcount
            framecount = 0;
        }

        if (isMoving)
        {
            //Hides marker when ball is moving 
            GetComponent<Renderer>().enabled = true;
        }
        else if (!isMoving)
        {
            GetComponent<Renderer>().enabled = true;
        }

        //Tests whether mousebutton is held down and 
        //Sets bool accordingly
        if (Input.GetMouseButtonDown(0))
        {
            isDown = true;
        }
        else if (Input.GetMouseButtonUp(0))
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
        float xAxis = Input.GetAxis("Mouse Y");

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

    void isMovingTest()
    {
        //Gets vector3 of cueball game object
        Vector3 objectVector3 = cue.transform.position;

        //Tests change in current vs last pos
        if (objectVector3 == lastPos)
        {
            isMoving = false;
        }
        else if (objectVector3 != lastPos)
        {
            isMoving = true;
        }

        lastPos = objectVector3;
    }
}
