using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Infected : BaseState
{

    public Infected(PawnStateController pawnStateController) : base("Infected", pawnStateController)
    {

    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("^^InfectedState^^");
        transform.GetComponentInParent<SpriteRenderer>().sprite = Resources.Load<Sprite>("INFPawn");

        transform.parent.AddComponent<CircleCollider2D>();
        transform.parent.GetComponent<CircleCollider2D>().radius = 10;
        transform.parent.GetComponent<CircleCollider2D>().isTrigger = true;

    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (transform.parent.tag == "Pawn")
        {
            // stateMachine.ChangeState(((PawnSM)stateMachine).defaultState); 
            Destroy(transform.parent.GetComponent<CircleCollider2D>());
            GetComponent<PawnStateController>().ChangeState(GetComponent<PawnStateController>().defaultState);
        }
    }

    public override void UpdatePhysics()
    {

    }
}
