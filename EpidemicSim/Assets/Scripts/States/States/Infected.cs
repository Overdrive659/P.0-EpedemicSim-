using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Infected : BaseState
{

    public Infected(PawnStateController pawnStateController) : base("Infected", pawnStateController)
    {

    }

    VarManager VarManager;
    [SerializeField] protected float sus;
    [SerializeField] protected int coughChance;
    [SerializeField] protected int sneezeChance;
    [SerializeField] private GameObject EmotePrefab;
    [SerializeField] private GameObject CloudPrefab;
    [SerializeField] protected float timerS = 0;
    public override void Enter()
    {
        base.Enter();
        transform.GetComponentInParent<SpriteRenderer>().sprite = Resources.Load<Sprite>("INFPawn");

        VarManager = GameObject.Find("GameManager").GetComponent<VarManager>();

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
            sneezeChance = Convert.ToInt32(sneezeChance * sus);

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
        return;
    }

    void Sneeze()
    {
        ShowText("*Sneezes!*");
        GameObject AerosolCloud = Instantiate(CloudPrefab, transform.position, Quaternion.identity);
        AerosolCloud.GetComponent<AerosolScript>().spawnedSus = sus;
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
