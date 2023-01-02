using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Vaccinated : BaseState
{
    public Vaccinated(PawnStateController pawnStateController) : base("Vaccinated", pawnStateController)
    {

    }

    public override void Enter()
    {
        base.Enter();
        transform.GetComponentInParent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Vaxxed-Pawn");

    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
    }



}
