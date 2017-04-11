using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour {

    [SerializeField] GameObject ray;

	void Update(){
        if (!InputManager.Instance.TriggerDown)
        {
            transform.position = ray.GetComponent<RayManager>().MarkerPosition;
            Debug.DrawRay(transform.position, Vector3.up, Color.blue);
        }

	}
	
}
