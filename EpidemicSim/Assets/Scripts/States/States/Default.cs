using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Default : BaseState
{

    [SerializeField] PawnController controller;

    public Default(PawnStateController pawnStateController) : base("Default", pawnStateController)
    {

    }

    public override void Enter()
    {
        base.Enter();
        controller = transform.GetComponentInParent<PawnController>();

        if (controller.hasMask)
        {
            Addressables.LoadAssetAsync<Sprite>("Assets/Resources_moved/MaskedPawn.png").Completed += (asyncOperationHandle) =>
            {
                if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
                {
                    transform.Find("SpriteObject").GetComponent<SpriteRenderer>().sprite = asyncOperationHandle.Result;
                }
                else
                {
                    Debug.Log("D_Pawn Spriteload FAILED!");
                }
            };
        }
        else
        {
            Addressables.LoadAssetAsync<Sprite>("Assets/Resources_moved/Pawn.png").Completed += (asyncOperationHandle) =>
            {
                if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
                {
                    transform.Find("SpriteObject").GetComponent<SpriteRenderer>().sprite = asyncOperationHandle.Result;
                }
                else
                {
                    Debug.Log("D_Pawn Spriteload FAILED!");
                }
            };
        }
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (transform.parent.CompareTag("IncubatingPawn"))
        {
            GetComponent<PawnStateController>().ChangeState(GetComponent<PawnStateController>().incubatingState);
        }
    }

    

}
