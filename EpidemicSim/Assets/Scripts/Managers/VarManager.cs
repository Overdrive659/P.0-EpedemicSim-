using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VarManager : MonoBehaviour
{
    public VarHolder VarHolder;

    public float minimumSusceptibility;
    public float maximumSusceptibility;
    public int cloudInfectionChance;
    public int coughChance;
    public int sneezeChance;
    public int hasMaskChance;
    public int breathRadius;
    public int areaInfectionChance;

    private void Awake()
    {
        minimumSusceptibility = VarHolder.minimumSusceptibility;
        maximumSusceptibility = VarHolder.maximumSusceptibility;
        cloudInfectionChance = VarHolder.cloudInfectionChance;
        coughChance = VarHolder.coughChance;
        breathRadius = VarHolder.breathRadius;
        hasMaskChance = VarHolder.hasMaskChance;
        breathRadius = VarHolder.breathRadius;
        cloudInfectionChance = VarHolder.cloudInfectionChance;
}

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
