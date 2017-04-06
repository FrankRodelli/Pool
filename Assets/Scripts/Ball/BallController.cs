using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Just a class that organizes the moving of the ball
public class BallController : MonoBehaviour{
	
    
	protected Ball _ball;
       
    // This function is for integration with unity editor.
    void Awake(){
       _ball = gameObject.GetComponent<Ball>();
    }

    protected void HitBall(Vector3 velocity){
        _ball.Rigidbody.AddForce(velocity);
        // play sound
        // etc...
    }
}
