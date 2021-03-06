﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager> {

	public float TriggerDownLength{get; private set;}
	public bool TriggerDown { get; private set;}
	public bool OnTriggerUp { get; private set;}
	public bool OnTriggerDown { get; private set;}
    public float MousePullBack { get; private set;}


	// Unity's native InputManager (Edit>ProjectSettings>Input) has support for different control schemes
	// But it is an absolute pain to work with, and doesn't support certain features you may want
	// As a result, Unity is currently remaking its InputManager, so for now, a class like this will do.
	// see : https://blogs.unity3d.com/2016/04/12/developing-the-new-input-system-together-with-you/ for what Unity is up to
	// Once that comes out, you'll no longer need to write your own InputManger
	void Update () {
		// see : https://msdn.microsoft.com/en-us/library/aa691309(v=vs.71).aspx
		TriggerDown = Input.GetMouseButton(0) | Input.GetKey(KeyCode.Space);
		OnTriggerUp = Input.GetMouseButtonUp(0) | Input.GetKey(KeyCode.Space);
		OnTriggerDown = Input.GetMouseButtonDown(0) | Input.GetKey(KeyCode.Space);
        MousePullBack = Input.GetAxis("Mouse X");
		if (TriggerDown){
			TriggerDownLength += Time.deltaTime;
		} else {
			TriggerDownLength = 0;
		}
    }
}
