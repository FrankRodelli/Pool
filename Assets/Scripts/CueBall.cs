using UnityEngine;
using System.Collections;

public class CueBall : MonoBehaviour {

    public Rigidbody rb;
    public float thrust;
    public float multiplier;
    public bool isDown = false;
    public GameObject target;
    public AudioSource breakSound;
    public GameObject scripts;

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
	
	}
	
	// Update is called once per frame
	void Update () {

    }

    private void LateUpdate()
    {
        //Calls addPower method
        if (scripts.GetComponent<PauseMenuTrigger>().isPaused)
        {
            //print("no move");
        }
        else {
            addPower();
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
            //Only allows force to be added if ball is not moving
            if (!target.GetComponent<Trajectory>().isMoving)
            {
                isDown = false;
                rb.AddForce((target.transform.position - transform.position) * thrust * multiplier/4);
                multiplier = 0;
                breakSound.Play();
            }

        }
    }
}
