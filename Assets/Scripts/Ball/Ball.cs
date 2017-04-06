using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Just a container
public class Ball : MonoBehaviour {
        // data
	[SerializeField] private float _radius;
	private Vector3 _cachedPosition;
	private Vector3 _position;
	private Vector3 _velocity;

    public Vector3 Velocity{
	    get { return _velocity;}
	}
	public Vector3 Position {
		get { return _position;}
	}

    // components
    private Rigidbody _rb;
    private BallController _controller;
    private SphereCollider _collider;
    private Material _material;

    public Rigidbody Rigidbody {
        get { return _rb; }
    }  
    public SphereCollider Collider {
        get { return _collider; }
    }
    public Material Material {
        get { return _material; }
    }        

	void Awake(){
		_rb = gameObject.GetComponent<Rigidbody>();
        _controller = gameObject.GetComponent<BallController>();
        _collider = gameObject.GetComponent<SphereCollider>();
        _material = gameObject.GetComponent<MeshRenderer>().material;
        _position = transform.position;
        _velocity = Vector3.zero;
	}

    // NOTE: this wont work properly unless the rigidbody's interpolation is changed from 'none' to 'interpolate'
    // This effectively 'syncs' the movement that happens in 'FixedUpdate' (rigidbody physics) with access to positional information in 'Update';
    // see: http://answers.unity3d.com/questions/767134/physics-what-is-interpolate-extrapolate-discrete-c.html

    // ALso, evidently Unity broke some shit with the 5.6 release, so its throwing errors when rigidbodies are set to interpolate, it should hopefully be resolved soon.
    // You can resolve the error for now by just setting the balls to 'none' interpolation, youll just see stuttery behavior on things
    // see : https://forum.unity3d.com/threads/in-order-to-call-gettransforminfoexpectuptodate-rendererupdatemanager-updateall-must-be-called-firs.459144/
	public void Update(){
		_velocity = transform.position - _cachedPosition; 
		_cachedPosition = transform.position;
		_position = _cachedPosition;
	}

}