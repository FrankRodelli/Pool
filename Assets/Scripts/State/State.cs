﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour {
    public abstract void Enter();
	public abstract void Exit();
	public abstract void Pause();
	public abstract void Resume();
	public abstract void UpdateState();
}

