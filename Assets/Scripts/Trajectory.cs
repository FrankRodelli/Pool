﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{ 
    //Variable initializers
    public int velocity;
    public bool isDown;
    public bool isMoving = false;
    public int framecount = 0;
    Vector3 initPosition;
    public Transform target;
    public Vector3 relativeDistance = Vector3.zero;
    public Vector3 lastPos = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        //Stores initial trajectory position
        initPosition = transform.position;

        relativeDistance = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        isMouseDown();

        //Adds 1 for time update is called
        framecount++;

        if (framecount == 5)
        {
            //Calls isMovingTest method
            isMovingTest();

            //Resets framcount
            framecount = 0;
        }
        //Calls movetrajectory method
        moveTrajectory();
    }

    void moveTrajectory()
    {
        //Updates transform based on cueball location
        transform.position = (target.position + relativeDistance);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.09f);

        //Working on this to reset position
        //transform.position = new Vector3(transform.position.x, transform.position.y, (GameObject.Find("raycast").GetComponent<RayCast>().theDistance / 2));

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

        //Reset relative position
        relativeDistance = transform.position - target.position;
        relativeDistance = new Vector3(relativeDistance.x, relativeDistance.y, relativeDistance.z + 0.09f);
    }

    void isMovingTest()
    {
        //Gets vector3 of cueball game object
        Vector3 objectVector3 = target.transform.position;

        Vector3 posChange = lastPos - objectVector3;

        //Tests change in current vs last pos
        if (posChange/10 == Vector3.zero/10)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }

        //Stores last position
        lastPos = objectVector3;

        if (isMoving)
        {
            //Hides marker when ball is moving 
            GetComponent<Renderer>().enabled = false;
        }
        else if (!isMoving)
        {
            GetComponent<Renderer>().enabled = true;
        }
    }
    
    //Tests whether mouse is held down and changes bool accordingly
    void isMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDown = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDown = false;
        }
    }
}
