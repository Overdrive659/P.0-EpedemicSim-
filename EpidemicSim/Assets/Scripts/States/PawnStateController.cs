using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class PawnStateController : MonoBehaviour
{
    public BaseState currentState;

    public Default defaultState;
    public Infected infectedState;
    public Vaccinated vaccinatedState;

    private void Awake()
    {
        defaultState = GetComponent<Default>();
        infectedState = GetComponent<Infected>();
    }
    // Start is called before the first frame update
    void Start()
    {
        currentState = GetInitialState();
        if (currentState != null)
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
        Debug.Log("GetInitialState has run correctly?");
        Debug.Log("The Pawn's tag IS:");
        Debug.Log(transform.parent.tag);


        if (transform.parent.tag == "Pawn")
        {
            Debug.Log("The pawn should set to default state");
            return defaultState;
        }
        if (transform.parent.tag == "InfectedPawn")
        {
            Debug.Log("The pawn should set to infected state");
            return infectedState;
        }
        else 
            return null;
    }
}
