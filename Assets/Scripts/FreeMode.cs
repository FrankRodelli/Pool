using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeMode : MonoBehaviour {

    public GameObject[] balls;
    public int numberOfBalls;

	// Use this for initialization
	void Start () {
        balls = GameObject.FindGameObjectsWithTag("PlayBall");

        for (int i = 0; i < balls.Length; i++)
        {
            numberOfBalls++;
        }
    }
	
	// Update is called once per frame
	void Update () {
        print(balls[0]);

	}
}
