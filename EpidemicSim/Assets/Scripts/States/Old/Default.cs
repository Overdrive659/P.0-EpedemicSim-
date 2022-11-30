using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Default : BaseState
{
    public Default(PawnStateController pawnStateController) : base("Default", pawnStateController)
    {

    }

    public override void Enter()
    {
        base.Enter();
        transform.GetComponentInParent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Pawn");

    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (transform.parent.tag == "InfectedPawn")
        {
            GetComponent<PawnStateController>().ChangeState(GetComponent<PawnStateController>().infectedState);
        }
    }

    

}
