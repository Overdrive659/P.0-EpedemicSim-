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
    VarManager VarManager;

    void Start()
    {
        VarManager = GameObject.Find("GameManager").GetComponent<VarManager>();

        endTime = UnityEngine.Random.Range(9, 15);
        startingSize = UnityEngine.Random.Range(3f, 6f);
        transform.localScale = new Vector3(startingSize, startingSize, startingSize);

        //float densityDecrease = cloudDensity / (endTime - startingSize);
        timeStep = (endTime / cloudDensity);
        tmpTime = timeStep;

        //SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        //spriteRenderer.color = new Color(0, 0, 0, 1f);
    }

    void Update()
    {
        timer += Time.deltaTime * 0.6f;
        //int seconds = Convert.ToInt32(timer % 60);

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

        if (col.gameObject.CompareTag("Pawn"))
        {
            int chance = UnityEngine.Random.Range(0, 101);

            chance = Convert.ToInt32(chance * spawnedSus * (cloudDensity/100));

            if (chance > VarManager.cloudInfectionChance)
            {
                col.gameObject.tag = "IncubatingPawn";
            }
        }

    }

}
