using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Infected : BaseState
{

    public Infected(PawnStateController pawnStateController) : base("Infected", pawnStateController)
    {

    }

    VarManager VarManager;
    [SerializeField] PawnController controller;

    [SerializeField] protected float sus;
    [SerializeField] protected int coughChance;
    [SerializeField] protected int sneezeChance;
    [SerializeField] private GameObject EmotePrefab;
    [SerializeField] private GameObject CloudPrefab;
    [SerializeField] protected float timerS = 0;
    public override void Enter()
    {
        base.Enter();

        //Define
        controller = transform.GetComponentInParent<PawnController>();


        if(controller.hasMask)
        {
            Addressables.LoadAssetAsync<Sprite>("Assets/Resources_moved/MaskedINFPawn.png").Completed += (asyncOperationHandle) =>
            {
                if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
                {
                    transform.Find("SpriteObject").GetComponent<SpriteRenderer>().sprite = asyncOperationHandle.Result;
                }
                else
                {
                    Debug.Log("INFpawn Spriteload FAILED!");
                }
            };
        }
        else
        {
            Addressables.LoadAssetAsync<Sprite>("Assets/Resources_moved/INFPawn.png").Completed += (asyncOperationHandle) =>
            {
                if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
                {
                    transform.Find("SpriteObject").GetComponent<SpriteRenderer>().sprite = asyncOperationHandle.Result;
                }
                else
                {
                    Debug.Log("INFpawn Spriteload FAILED!");
                }
            };
        }

        //Addressing AeroCloud
        Addressables.LoadAssetAsync<GameObject>("Assets/AerosolCloud.prefab").Completed += (asyncOperationHandle) =>
        {
            if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
            {
                CloudPrefab = asyncOperationHandle.Result;
            }
            else
            {
                Debug.Log("INFPawn AeroCloud Prefab Load Failed!");
            }
        };

        /* TEMPORARILY DEPRECATED
        //Sprite Setting
        if (controller.hasMask)
        {
            transform.GetComponentInParent<SpriteRenderer>().sprite = Resources.Load<Sprite>("MaskedINFPawn");
        }
        else
            transform.GetComponentInParent<SpriteRenderer>().sprite = Resources.Load<Sprite>("INFPawn");

        */

        //Define
        VarManager = GameObject.Find("GameManager").GetComponent<VarManager>();

        //Breath Collider Spawn
        if (!(transform.parent.GetComponent<CircleCollider2D>()))
        {
            transform.parent.AddComponent<CircleCollider2D>();
            transform.parent.GetComponent<CircleCollider2D>().radius = VarManager.breathRadius;
            transform.parent.GetComponent<CircleCollider2D>().isTrigger = true;
        }

        sus = transform.GetComponentInParent<PawnController>().susVariable;

        StartCoroutine(SpreadSystem());
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (transform.parent.CompareTag("Pawn"))
        {
            // stateMachine.ChangeState(((PawnSM)stateMachine).defaultState); 
            Destroy(transform.parent.GetComponent<CircleCollider2D>());
            GetComponent<PawnStateController>().ChangeState(GetComponent<PawnStateController>().defaultState);
        }
    }

    IEnumerator SpreadSystem()
    {
        while (true)
        {
            coughChance = UnityEngine.Random.Range(1, 101);
            coughChance = Convert.ToInt32(coughChance * sus);
            sneezeChance = UnityEngine.Random.Range(1, 101);
            sneezeChance = Convert.ToInt32(sneezeChance * sus); //(sus + ((1 - sus) / 2))

            if (coughChance > VarManager.coughChance)
            {
                Cough();
            }
            if (sneezeChance > VarManager.sneezeChance)
            {
                Sneeze();
            }

            yield return new WaitForSeconds(3f);
        }
    }

    void Cough()
    {
        ShowText("*Coughs!*");
        GameObject AerosolCloud = Instantiate(CloudPrefab, transform.position, Quaternion.identity);
        AerosolCloud.GetComponent<AerosolScript>().spawnedSus = sus;
        AerosolCloud.GetComponent<AerosolScript>().hadMask = controller.hasMask;
        return;
    }

    void Sneeze()
    {
        ShowText("*Sneezes!*");
        GameObject AerosolCloud = Instantiate(CloudPrefab, transform.position, Quaternion.identity);
        AerosolCloud.GetComponent<AerosolScript>().spawnedSus = sus;
        AerosolCloud.GetComponent<AerosolScript>().hadMask = controller.hasMask;
            return;
    }

    void ShowText(string text)
    {
        if (EmotePrefab)
        {
            GameObject prefab = Instantiate(EmotePrefab, transform.position, Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = text;

        }
    }
}
