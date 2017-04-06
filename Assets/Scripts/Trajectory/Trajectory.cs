using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour {

    [SerializeField] private Ball _cueBall;

    // Use this for initialization
    void Start()
    {
        MoveToCueBall();
        RotateAroundCueBall();

    }

    // Update is called once per frame
    void Update()
    {
        if (_cueBall.Velocity.magnitude == 0)
        {
            MoveToCueBall();
            RotateAroundCueBall();
        }
    }

    void MoveToCueBall()
    {
        transform.position = _cueBall.Position;
    }

    void RotateAroundCueBall()
    {
        Vector2 cueballKey = _cueBall.Position.xz(); // see the Vector3Extensions.cs class to know what .xz() does 
        Vector2 markerKey = InputManager.Instance.MarkerPosition.xz();

        Vector3 delta = (markerKey - cueballKey).normalized.x_y(0); // see the Vector2Extensions.cs class to know what .x_y() does 

        transform.forward = delta;
    }
}
