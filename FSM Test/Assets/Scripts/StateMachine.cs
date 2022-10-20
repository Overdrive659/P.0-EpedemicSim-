using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Services.Core;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
        BaseState currentState;

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

    //Displays current state on screen
    private void OnGUI()
    {
        string content = Convert.ToString(currentState);
        if(currentState == null)
        {
            content = "no current state";
        }
        GUILayout.Label(content);
    }
}

public class BaseState
{
    public string name;
    protected StateMachine stateMachine;

    //Constructor which takes in a name and an assigned SM which allows you to create new states
    //using this class!
    public BaseState(string name, StateMachine stateMachine)
    {
        this.name = name;
        this.stateMachine = stateMachine;
    }
    public virtual void Enter()
    {

    }

    public virtual void UpdateLogic()
    {

    }

    public virtual void UpdatePhysics()
    {

    }

    public virtual void Exit()
    {

    }
}