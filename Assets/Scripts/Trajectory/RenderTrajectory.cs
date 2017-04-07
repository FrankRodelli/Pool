using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderTrajectory : MonoBehaviour {

    [SerializeField] private Ball _cueBall;
	
	// Update is called once per frame
	void Update () {
		if(_cueBall.Velocity.magnitude == 0)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
        }
        else if(_cueBall.Velocity.magnitude > 0)
        {
            gameObject.GetComponent<Renderer>().enabled = false;
        }
	}
}
