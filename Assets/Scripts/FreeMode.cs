using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeMode : MonoBehaviour {

    public GameObject[] ball;
    public int numberOfBalls;
    public bool isGameOver = false;

	// Use this for initialization
	void Start () {

        //Sets balls to gameobject array
        ball = GameObject.FindGameObjectsWithTag("PlayBall");

        //Gets number of balls from array
        numberOfBalls = ball.Length;
    }
	
	// Update is called once per frame
	void Update () {

        if(numberOfBalls == 0)
        {
            Application.LoadLevel("PoolTable");
        }

	}
}
