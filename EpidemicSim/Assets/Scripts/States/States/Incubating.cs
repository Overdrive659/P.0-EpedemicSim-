using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Incubating : BaseState
{
    public Incubating(PawnStateController pawnStateController) : base("Default", pawnStateController)
    {

    }

    public VarManager VarManager;
    [SerializeField] protected float sus;

    public override void Enter()
    {
        base.Enter();
        transform.GetComponentInParent<SpriteRenderer>().sprite = Resources.Load<Sprite>("IncubPawn");
        VarManager = GameObject.Find("GameManager").GetComponent<VarManager>();
        sus = transform.GetComponentInParent<PawnController>().susVariable;
        StartCoroutine(WaitSystem());
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (transform.parent.CompareTag("InfectedPawn"))
        {
            GetComponent<PawnStateController>().ChangeState(GetComponent<PawnStateController>().infectedState);
        }

    }

    IEnumerator WaitSystem()
    {
        yield return new WaitForSeconds(20);
        transform.parent.tag = "InfectedPawn";
    }
}

