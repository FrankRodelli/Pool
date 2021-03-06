﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueStick : MonoBehaviour {

	[SerializeField] private Ball _cueBall;
    [SerializeField] private GameObject _rayScript;
	[SerializeField] private float _maxPullDist = 1;
	[SerializeField] private AnimationCurve _pullCurve;
	[SerializeField] private AnimationCurve _releaseCurve;
	[SerializeField] private float _releaseTimeScalar = 1;

	

	private float _pullDist;
	private float _distAtRelease;
	private float _cachedPullTime;
	private float _cachedReleaseTime;

	private Vector3 _baseCueOffset;
	private Transform _cue;

	void Start () {
       	_cue = transform.Find("MeshObject");
       	_baseCueOffset = _cue.transform.localPosition;

       	MoveToCueBall();
		RotateAroundCueBall();
    }

	void Update () {
		if (_cueBall.Velocity.magnitude == 0 && !InputManager.Instance.TriggerDown) {
            MoveToCueBall();
			RotateAroundCueBall();
		}
		SetCuePosition();

	}

	void MoveToCueBall(){
		transform.position = _cueBall.Position;
	}

	void RotateAroundCueBall(){
		Vector2 cueballKey = _cueBall.Position.xz(); // see the Vector3Extensions.cs class to know what .xz() does 
		Vector2 markerKey = _rayScript.GetComponent<RayManager>().MarkerPosition.xz();
        transform.forward = (markerKey - cueballKey).normalized.x_y(0);//Shortened this to one line 
	}

	void SetCuePosition(){

		if (InputManager.Instance.TriggerDown){
			PullCue();
			_cachedReleaseTime = 0;
		} else if (InputManager.Instance.OnTriggerUp){
			_distAtRelease = _pullDist;
			_cachedPullTime = 0;
			ReleaseCue();
		} else {
			ReleaseCue();
		}

		Vector3 pos = _baseCueOffset;
		pos.z += _pullDist* -_maxPullDist;
		_cue.localPosition = pos;

	}

	void PullCue(){
		_cachedPullTime += InputManager.Instance.MousePullBack / 10 * -1;
		float pullValue = _pullCurve.Evaluate(_cachedPullTime); 
		_pullDist = pullValue;
	}

	void ReleaseCue(){
		_cachedReleaseTime += Time.deltaTime/_releaseTimeScalar * 2;
		float releaseValue = _releaseCurve.Evaluate(_cachedReleaseTime)*_distAtRelease;
		//_pullDist = Mathf.Lerp(_pullDist,0,releaseValue); 
		_pullDist = releaseValue;
	}

}
