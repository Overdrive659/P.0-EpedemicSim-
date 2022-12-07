using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Infected : BaseState
{

    public Infected(PawnStateController pawnStateController) : base("Infected", pawnStateController)
    {

    }

    public float sus;
    public int coughChance;
    public override void Enter()
    {
        base.Enter();
        transform.GetComponentInParent<SpriteRenderer>().sprite = Resources.Load<Sprite>("INFPawn");

        if (!(transform.parent.GetComponent<CircleCollider2D>()))
        {
            transform.parent.AddComponent<CircleCollider2D>();
            transform.parent.GetComponent<CircleCollider2D>().radius = 10;
            transform.parent.GetComponent<CircleCollider2D>().isTrigger = true;
        }

        sus = transform.GetComponentInParent<PawnController>().susVariable;

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

        coughChance = UnityEngine.Random.Range(1, 100);
        coughChance = Convert.ToInt32(coughChance / sus);

    }

    public override void UpdatePhysics()
    {
        if(coughChance > 50)
        {
            Cough();
        }
    }

    public void Cough()
    {

        return;
    }
}
