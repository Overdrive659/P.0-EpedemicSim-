using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerosolScript : MonoBehaviour
{
    [SerializeField] private float timer = 0.0f;
    [SerializeField] private float cloudDensity = 100;
    [SerializeField] private int endTime;
    private float startingSize;
    private float timeStep;
    private float tmpTime;
    [SerializeField] public float spawnedSus;
    [SerializeField] public bool hadMask;
    VarManager VarManager;

    void Start()
    {
        VarManager = GameObject.Find("GameManager").GetComponent<VarManager>();

        endTime = UnityEngine.Random.Range(9, 15);
        
        timeStep = (endTime / cloudDensity);
        tmpTime = timeStep;

        //Calculate size based on mask
        if(hadMask)
        {
            startingSize = UnityEngine.Random.Range((3f * (spawnedSus + ((1 - spawnedSus) / 2))),(6f * (spawnedSus + ((1 - spawnedSus) / 2))));
            startingSize = startingSize * 0.6f;
        }
        else
        {
            startingSize = UnityEngine.Random.Range((3f * (spawnedSus + ((1 - spawnedSus) / 2))), (6f * (spawnedSus + ((1 - spawnedSus) / 2))));
        }

        
        transform.localScale = new Vector3(startingSize, startingSize, startingSize);

    }

    void Update()
    {
        timer += Time.deltaTime * 0.6f;

        //Try removing 2 steps from Density in the first half of the timer, then 0.5 in the second half to simulate heavy droplets falling out.
        if(timer > tmpTime)
        {
            tmpTime += timeStep;
            cloudDensity = cloudDensity - 1;
        }

        if (timer > transform.localScale.x)
        {
            transform.localScale = new Vector3(timer, timer, timer);
        }

        if (timer > endTime)
        {
            Destroy(gameObject);
        }

    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        //float targetSus = col.gameObject.GetComponent<PawnController>().susVariable;

        int chance = UnityEngine.Random.Range(0, 101);

        chance = Convert.ToInt32(chance * spawnedSus * (cloudDensity / 100)); //targetSus

        switch (col.gameObject.tag)
        {
            case "Pawn":
                if (hadMask)
                {
                    if ((chance * 0.6f) > VarManager.cloudInfectionChance)
                    {
                        col.gameObject.tag = "IncubatingPawn";
                    }
                }
                else
                {
                    if (chance > VarManager.cloudInfectionChance)
                    {
                        col.gameObject.tag = "IncubatingPawn";
                    }
                }
                break;

            case "VaccinatedPawn":
                if (hadMask)
                {
                    if (((chance * 0.6f) * 0.25f) > VarManager.cloudInfectionChance)
                    {
                        col.gameObject.tag = "IncubatingPawn";
                    }
                }
                else
                {
                    if ((chance * 0.25f) > VarManager.cloudInfectionChance)
                    {
                        col.gameObject.tag = "IncubatingPawn";
                    }
                }
                break;
        }

    }

}
