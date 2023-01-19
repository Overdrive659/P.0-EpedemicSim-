using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VarManager : MonoBehaviour
{
    public float minimumSusceptibility = 0;
    public float maximumSusceptibility = 1;
    public int cloudInfectionChance = 45;
    public int coughChance = 55;
    public int sneezeChance = 35;
    public int hasMaskChance = 50;
    public int breathRadius = 5;
    public int areaInfectionChance = 1;

    // Start is called before the first frame update
    void Start()
    {
        areaInfectionChance = 100 - areaInfectionChance;
        cloudInfectionChance = 100 - cloudInfectionChance;
        coughChance = 100 - coughChance;
        sneezeChance = 100 - sneezeChance;
        hasMaskChance= 100 - hasMaskChance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
