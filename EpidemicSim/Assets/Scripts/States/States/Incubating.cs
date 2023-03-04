using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Incubating : BaseState
{
    public Incubating(PawnStateController pawnStateController) : base("Default", pawnStateController)
    {

    }

    [SerializeField] VarManager VarManager;
    [SerializeField] protected float sus;
    [SerializeField] DataManager DataManager;
    [SerializeField] Timer Timer;

    [SerializeField] PawnController controller;

    public override void Enter()
    {
        base.Enter();

        controller = transform.GetComponentInParent<PawnController>();


        //Sprite Setting
        if (controller.hasMask)
        {
            Addressables.LoadAssetAsync<Sprite>("Assets/Resources_moved/MaskedIncubPawn.png").Completed += (asyncOperationHandle) =>
            {
                if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
                {
                    transform.Find("SpriteObject").GetComponent<SpriteRenderer>().sprite = asyncOperationHandle.Result;
                }
                else
                {
                    Debug.Log("Incub_Pawn Spriteload FAILED!");
                }
            };
        }
        else
        {
            Addressables.LoadAssetAsync<Sprite>("Assets/Resources_moved/IncubPawn.png").Completed += (asyncOperationHandle) =>
            {
                if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
                {
                    transform.Find("SpriteObject").GetComponent<SpriteRenderer>().sprite = asyncOperationHandle.Result;
                }
                else
                {
                    Debug.Log("Incub_Pawn Spriteload FAILED!");
                }
            };


            //Defines
            VarManager = GameObject.Find("GameManager").GetComponent<VarManager>();
            DataManager = GameObject.Find("GameManager").GetComponent<DataManager>();
            Timer = GameObject.Find("GameManager").GetComponent<Timer>();

            sus = transform.GetComponentInParent<PawnController>().susVariable;

            //Data Collection
            VarManager.totalInfected = VarManager.totalInfected + 1;
            DataManager.InfectionOverTimeS.Add(Tuple.Create(Timer.secondsPassed, VarManager.totalInfected));

            DataManager.InfectionLocations.Add(new Vector2(transform.position.x, transform.position.y));

            StartCoroutine(WaitSystem());
        }
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
        yield return new WaitForSeconds(Convert.ToInt16(VarManager.incubationTime * sus));
        transform.parent.tag = "InfectedPawn";
    }
}

