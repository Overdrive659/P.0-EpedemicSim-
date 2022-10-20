using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState : MonoBehaviour
{
    protected PawnStateController PawnStateController;

    //Constructor which takes in a name and an assigned State Machine which allows you to create new states
    //using this class!
    public BaseState(string name, PawnStateController pawnStateController)
    {
        this.name = name;
        this.PawnStateController = pawnStateController;
    }

    //Below are methods that are called in order, input logic as needed.
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
