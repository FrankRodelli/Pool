using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryVisualizer : MonoBehaviour
{

    [SerializeField] private Ball _cueBall;
    [SerializeField] private Transform _marker;
    [SerializeField] private RayManager _rayScript;

    private LineRenderer _line;

    // Use this for initialization
    void Start()
    {
        _line = gameObject.GetComponent<LineRenderer>();
        MoveToCueBall();
        RotateAroundCueBall();
        AdjustLine();
    }

    void Update()
    {
        if (_cueBall.Velocity.magnitude == 0 && !InputManager.Instance.TriggerDown)
        {
            MoveToCueBall();
            RotateAroundCueBall();
            AdjustLine();
            LineVisible(true);
        }
        else
        {
            LineVisible(false);
        }
    }

    void AdjustLine()
    {
        _line.SetPosition(1, _rayScript.TrajectoryRayHit);
        _line.SetPosition(0, transform.position);
    }

    void MoveToCueBall()
    {
        transform.position = _cueBall.Position;
    }

    void RotateAroundCueBall()
    {
        Vector2 cueballKey = _cueBall.Position.xz(); // see the Vector3Extensions.cs class to know what .xz() does 
        //Vector2 markerKey = RayManager.Instance.MarkerPosition.xz();
        Vector2 markerKey = _marker.position.xz();
        transform.forward = (markerKey - cueballKey).normalized.x_y(0);//Shortened this to one line 
    }

    void LineVisible(bool enabled)
    {
        _line.enabled = enabled;
    }
}