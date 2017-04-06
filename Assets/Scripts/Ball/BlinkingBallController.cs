using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Just an update handler 
public class BlinkingBallController : BallController {
    // Data
    [SerializeField] private Vector2 _powerRange = new Vector2(.5f, 2); // set up default so its not ever Vector2.zero;
    [SerializeField] private float _interval;
    private float _cachedTime;

    // at each interval, hit the ball in a random direction
    public void Update(){
        _cachedTime += Time.deltaTime;
        if (_cachedTime > _interval){
        	//yay trigonometry
            float randDegree = Random.Range(0,360);
            float radian = randDegree * Mathf.Deg2Rad;
            Vector3 velocity = new Vector3(Mathf.Cos(radian),0,Mathf.Sin(radian));
            
            float power = Random.Range(_powerRange.x,_powerRange.y);

            HitBall(velocity*power);
            _cachedTime = 0;
        }
    }
}