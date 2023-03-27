using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Voxus.Random;

public class SusGenerator : MonoBehaviour
{
    VarManager VarManager;
    RandomGaussian GRND;
    protected float susMu;
    protected float susSigma;

    private void Awake()
    {
        VarManager = GameObject.Find("GameManager").GetComponent<VarManager>();


    }

    private void Start()
    {
        //Calculates Gaussian Vars
        //Mean value, where most values will be generated (the middle)
        susMu = (VarManager.minimumSusceptibility + VarManager.maximumSusceptibility) / 2f;
        //The tails of the bellcurve, which points will values not generate byond
        susSigma = (VarManager.maximumSusceptibility - VarManager.minimumSusceptibility);

        //sets the values
        GRND = new RandomGaussian((susSigma), (susMu));

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            GeneratorFunction();
        }
    }
    public float GeneratorFunction()
    {
        float generatedSus = GRND.Get();
        Debug.Log(generatedSus);
        return generatedSus;
    }

}
