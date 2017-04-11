using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayManager : MonoBehaviour {

    [SerializeField] private Transform _trajectory;
    [SerializeField] private LayerMask _markerPlaneMask;

    private Vector3 _markerPosition;
    private Vector3 _trajectoryRayHit;
    private float _distance;

    //public getters
    public Vector3 MarkerPosition { get { return _markerPosition; } }
    public Vector3 TrajectoryRayHit { get { return _trajectoryRayHit; } }
    public float Distance { get { return _distance; } }

    void Update () {

        Camera cam = Camera.main;
        RaycastHit hit;
        // sends a ray out from the camera
        if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, _markerPlaneMask) && !InputManager.Instance.TriggerDown)
        {

            _markerPosition = hit.point;
            Debug.DrawLine(cam.transform.position, hit.point, Color.red);
        }

        RaycastHit hitBall;

        if (Physics.SphereCast(_trajectory.position, .5f, _trajectory.forward, out hitBall, 50))
        {
            _distance = hitBall.distance;
            _trajectoryRayHit = hitBall.point;
            Debug.DrawLine(_trajectory.position, hitBall.point, Color.cyan);
        }
    }
}