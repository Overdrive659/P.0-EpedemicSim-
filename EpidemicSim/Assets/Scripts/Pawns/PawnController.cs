using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PawnController : MonoBehaviour
{
    VarManager VarManager;
    
    public bool hasMask;
    public float susVariable;

    //MOVEMENT SYSTEM
    [SerializeField] Vector3 target;

    private NavMeshAgent agent;

    private void Awake()
    {
        VarManager = GameObject.Find("GameManager").GetComponent<VarManager>();
        susVariable = UnityEngine.Random.Range(VarManager.minimumSusceptibility, VarManager.maximumSusceptibility);

        int maskChance = UnityEngine.Random.Range(0, 101);

        if(maskChance > VarManager.hasMaskChance)
        {
            hasMask = true;
        }

        agent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {

        agent.speed = UnityEngine.Random.Range(6f, 12f);
        agent.acceleration = agent.speed;

        agent.SetDestination(PositionGenerator());
        target = agent.destination;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target, transform.position) <= 5)
        { 
            target = PositionGenerator();
            agent.SetDestination(target);
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
       if(col.gameObject.CompareTag("Pawn"))
        {
            int chance = UnityEngine.Random.Range(0, 101);

            if(hasMask)
            {
                if (((chance / 2) * susVariable) > VarManager.areaInfectionChance)
                {
                    col.gameObject.tag = "IncubatingPawn";
                }
            }
            else
            {
                if ((chance * susVariable) > VarManager.areaInfectionChance)
                {
                    col.gameObject.tag = "IncubatingPawn";
                }
            }
        }
        
    }

    private Vector3 PositionGenerator()
    {
        Vector3 RNDPosition = new Vector3(UnityEngine.Random.Range(-374, 374), UnityEngine.Random.Range(-366, 372));

        return RNDPosition;
    }

}
