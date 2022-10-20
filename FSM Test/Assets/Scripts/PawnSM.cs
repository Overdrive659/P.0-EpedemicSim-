using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnSM : StateMachine
{
    [HideInInspector]
    public Idle idleState;
    [HideInInspector]
    public Infected infectedState;

    private void Awake()
    {
        idleState = new Idle(this);
        infectedState = new Infected(this);
    }
    protected override BaseState GetInitialState()
    {
        return idleState;
    }
}
