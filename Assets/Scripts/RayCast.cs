using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour {

    public float theDistance;
    public GameObject target;
    public Ray ray;
    public RaycastHit hit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Debug raycast so we can see it in the editor
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);

        if (Physics.Raycast(transform.position,(forward),out hit))
        {
            theDistance = hit.distance;
            //print(theDistance + " " + hit.collider.gameObject.name);

            Vector3 initPosition = target.transform.position;

            target.transform.localScale = new Vector3(0.05f, 0.05f, theDistance/70);


        }



    }
}
