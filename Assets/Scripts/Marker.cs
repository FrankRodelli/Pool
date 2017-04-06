using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour {

	void Update(){
		transform.position = InputManager.Instance.MarkerPosition;
		Debug.DrawRay(transform.position,Vector3.up,Color.blue);
	}
	
}
