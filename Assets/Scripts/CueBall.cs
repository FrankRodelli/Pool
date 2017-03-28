using UnityEngine;
using System.Collections;

public class CueBall : MonoBehaviour {

	Vector3 initPosition;
    public Rigidbody rb;
    public float thrust;
    public float multiplier;
    public bool isDown = false;

	// Use this for initialization
	void Start () {

		initPosition = transform.position;

        rb = GetComponent<Rigidbody>();

        Cursor.visible = false;
	
	}
	
	// Update is called once per frame
	void Update () {

        //Calls addPower method
        addPower();
        var ballPositionX = transform.position.x;
        var ballPositionZ = transform.position.z;

        if (ballPositionX > 3.80 || ballPositionX < -3.80)
        {
            transform.position = initPosition;
            print("Ball Reset");
        }
    }

    //Sets multiplier variable based on mouse movement
    void Multiplier()
    {
        multiplier = multiplier + Input.GetAxis("Mouse Y");

        //Resets multipler so it can't be negative
        if (multiplier < 0)
        {
            multiplier = 0;
        }

        //Need to add logic to not allow over a certain power
    }

    void addPower()
    {
        //Gets trajectory game object
        GameObject trajectory = GameObject.Find("trajectory");

        //Sets velocity based on mouse movement
        if (Input.GetMouseButtonDown(0))
        {
            isDown = true;
        }

        //If isdown, executes multiplier method
        if (isDown)
        {
            Multiplier();
        }

        //Applies force when mouseup left click is detected
        if (Input.GetMouseButtonUp(0))
        {
            isDown = false;
            rb.AddForce((trajectory.transform.position - transform.position) * thrust * multiplier);
            multiplier = 0;
        }
    }
}
