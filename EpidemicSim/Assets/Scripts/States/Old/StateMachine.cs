using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Services.Core;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
        public BaseState currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = GetInitialState();
        if(currentState != null)
        {
            currentState.Enter();
        }
    }

    // Update is called first once per frame
    // If we have a current state, it will call the function to run its logic
    void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateLogic();
        }
    }

    // Late Update runs last, once per frame
    // If we have a current state, it will call the function to run the physics logic
    // of the current state
    void LateUpdate()
    {
        if (currentState != null)
        {
            currentState.UpdatePhysics();
        }
    }


    public void ChangeState(BaseState newState)
    {
        //Calls exit function of class to make sure it ends properly
        currentState.Exit();

        //Changes current state to the new State and runs the new State's enter function
        currentState = newState;
        currentState.Enter();
    }

    protected virtual BaseState GetInitialState()
    {
        return null;
    }
}