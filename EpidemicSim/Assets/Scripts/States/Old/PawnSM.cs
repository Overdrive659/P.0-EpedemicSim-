using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnSM : StateMachine
{
    public Default defaultState;
    public Infected infectedState;

    private void Awake()
    {
        defaultState = GetComponent<Default>();
        infectedState = GetComponent<Infected>();
    }
    protected override BaseState GetInitialState()
    {
        return defaultState;
    }
}
