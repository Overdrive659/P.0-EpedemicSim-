using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerosolScript : MonoBehaviour
{
    public float timer = 0.0f;
    public float cloudDensity = 100;
    public int endTime;
    float startingSize;
    public float timeStep;
    public float tmpTime;

    // Start is called before the first frame update
    void Start()
    {
        
        endTime = UnityEngine.Random.Range(9, 15);
        startingSize = UnityEngine.Random.Range(3f, 6f);
        transform.localScale = new Vector3(startingSize, startingSize, startingSize);
        //float densityDecrease = cloudDensity / (endTime - startingSize);
        timeStep = (endTime / cloudDensity);
        tmpTime = timeStep;
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * 0.3f;
        //int seconds = Convert.ToInt32(timer % 60);

        //skapa en if sats, om timern är större än timestep så ökar en tmp variabel med timestep och cloud density minskas
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

        if (col.gameObject.tag == "Pawn")
        {
            int chance = UnityEngine.Random.Range(0, 100);

            chance = Convert.ToInt32(chance * (cloudDensity/100));
            Debug.Log(chance);

            if (chance > 50)
            {
                col.gameObject.tag = "InfectedPawn";
            }
        }

    }

}
