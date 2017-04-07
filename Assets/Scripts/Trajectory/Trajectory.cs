using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour {

    [SerializeField] private Ball _cueBall;
    [SerializeField] private GameObject _trajectoryObject;
    private LineRenderer lineRenderer;

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
            ResizeTrajectory();
        }
    }

    void CreateLine()
    {
        //TODO: Implement createline to cast line on ray
        /*lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startColor = Color.black;
        lineRenderer.startWidth = 5;
        lineRenderer.numPositions = 2;

        lineRenderer.SetPosition(0, new Vector3(2, 2, 2));
        lineRenderer.SetPosition(0, new Vector3(4, 4, 4));*/
    }

    void MoveToCueBall()
    {
        transform.position = _cueBall.Position;
    }

    void RotateAroundCueBall()
    {
        Vector2 cueballKey = _cueBall.Position.xz(); // see the Vector3Extensions.cs class to know what .xz() does 
        Vector2 markerKey = InputManager.Instance.MarkerPosition.xz();
        transform.forward = (markerKey - cueballKey).normalized.x_y(0);//Shortened this to one line 
    }

    //Resizes trajectory based on ray
    void ResizeTrajectory()
    {
        _trajectoryObject.transform.localScale = new Vector3(1.2f, 1.2f, InputManager.Instance.Distance/4.685f);
        print(InputManager.Instance.Distance);
    }

    void DrawLine()
    {

    }
}
