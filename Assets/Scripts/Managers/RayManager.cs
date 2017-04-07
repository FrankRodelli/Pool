using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayManager : Singleton<RayManager> {

    [SerializeField] private GameObject _trajectory;
    [SerializeField] private LayerMask _markerPlaneMask;

    public Vector3 MarkerPosition { get; private set; }
    public Vector3 TrajectoryRayHit { get; private set; }
    public float Distance { get; private set; }

    void Update () {

        Camera cam = Camera.main;
        RaycastHit hit;
        // sends a ray out from the camera
        if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, _markerPlaneMask))
        {

            MarkerPosition = hit.point;
            Debug.DrawLine(cam.transform.position, hit.point, Color.red);
        }

        RaycastHit hitBall;

        if (Physics.SphereCast(_trajectory.transform.position, .5f, _trajectory.transform.forward, out hitBall, 50))
        {
            Distance = hitBall.distance;
            TrajectoryRayHit = hitBall.point;
            Debug.DrawLine(_trajectory.transform.position, hitBall.point, Color.cyan);
        }
    }
}
