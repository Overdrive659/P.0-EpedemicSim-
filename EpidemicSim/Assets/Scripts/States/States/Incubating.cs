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
    [SerializeField] DataManager DataManager;
    [SerializeField] Timer Timer;

    public override void Enter()
    {
        base.Enter();
        transform.GetComponentInParent<SpriteRenderer>().sprite = Resources.Load<Sprite>("IncubPawn");

        VarManager = GameObject.Find("GameManager").GetComponent<VarManager>();
        DataManager = GameObject.Find("GameManager").GetComponent<DataManager>();
        Timer = GameObject.Find("GameManager").GetComponent<Timer>();

        sus = transform.GetComponentInParent<PawnController>().susVariable;

        //Data Collection
        VarManager.totalInfected = VarManager.totalInfected +1;
        DataManager.InfectionOverTimeS.Add(Tuple.Create(Timer.secondsPassed, VarManager.totalInfected));

        DataManager.InfectionLocations.Add(new Vector2(transform.position.x, transform.position.y));

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

