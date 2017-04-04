using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueMarker : MonoBehaviour {

    public GameObject target;
    public float distance;
    public Vector3 trajPosition;
    public GameObject scripts;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        setPosition();

        //Disables renderer if cueball is moving
        if (GameObject.Find("traj").GetComponent<Trajectory>().isMoving)
        {
            GetComponent<Renderer>().enabled = false;
        }
        else
        {
            GetComponent<Renderer>().enabled = true;
        }
    }

    private void LateUpdate()
    {

    }

    void setPosition()
    {
        //Sets position of marker to end of raycast
        //TODO: need to offset the ball on the z axis correctly
        transform.position = target.GetComponent<RayCast>().hit.point;
    }
}
