using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// fileName is the default name when creating a new Instance
// menuName is where to find it in the context menu of Create
[CreateAssetMenu(fileName = "SimData", menuName = "DataStructures/SimVariables")]
public class VarHolder : ScriptableObject
{
    public float minimumSusceptibility;
    public float maximumSusceptibility;
    public int cloudInfectionChance;
    public int coughChance;
    public int sneezeChance;
    public int hasMaskChance;
    public int breathRadius;
    public int areaInfectionChance;

    public int? uninfectedPawnAmount;
    public int? infectedPawnAmount;
    public int? vaccinatedPawnAmount;
    public int? maskedPawnAmount;

    public int simHours;
    public int simMinutes;
}

