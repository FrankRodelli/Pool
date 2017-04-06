using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// example of a state machine that you would use to handle things like Play/Pause -- You want as few references to this as possible! Strictly need to know basis!
public class StateMachine : MonoBehaviour {
      
    private State _currentState;
    public State CurrentState{ get {return _currentState;}}

    public void Init(State state){
        _currentState = state;
        _currentState.Enter();
    }

    public void ChangeState(State newState){
        if (_currentState != null){
             _currentState.Exit();
        }

        _currentState = newState;

        if (_currentState != null){
             _currentState.Enter();
       	}
    }

    void Update(){
        if(_currentState != null){
            _currentState.UpdateState();
        }
    }
}
