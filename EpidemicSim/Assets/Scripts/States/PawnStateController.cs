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
    public Incubating incubatingState;

    private void Awake()
    {
        defaultState = GetComponent<Default>();
        infectedState = GetComponent<Infected>();
        vaccinatedState = GetComponent<Vaccinated>();
        incubatingState = GetComponent<Incubating>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //Checks if it already has a state.
        //If it doesn't, check its tag and return a state depending.
        //Run the enter function on said state
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
        if (transform.parent.tag == "Pawn")
        {
            return defaultState;
        }
        if (transform.parent.tag == "InfectedPawn")
        {
            return infectedState;
        }
        if (transform.parent.tag == "VaccinatedPawn")
        {
            return vaccinatedState;
        }
        if (transform.parent.tag == "IncubatingPawn")
        {
            return incubatingState;
        }
        else 
            return null;
    }
}
