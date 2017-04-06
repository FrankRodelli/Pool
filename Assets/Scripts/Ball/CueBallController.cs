using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Just an update handler
public class CueBallController : BallController {

	[SerializeField] private float _power;
	[SerializeField] private Transform _target;
	
	public void Update(){
        if (InputManager.Instance.OnTriggerUp && _ball.Velocity.magnitude == 0){
    		Vector3 velocity = (_target.position - _ball.Position).normalized * _power;
     		HitBall(velocity);
        }

	}

}