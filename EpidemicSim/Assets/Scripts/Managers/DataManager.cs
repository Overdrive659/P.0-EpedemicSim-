using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System;

public class DataManager : MonoBehaviour
{
    [SerializeField] VarManager VarManager;
    [SerializeField] Timer Timer;
    [SerializeField] VarHolder VarHolder;
 
    public int totInfected;

    string mainPath;

    // List for total Infections + Timestamp in seconds
    public List<Tuple<int, int>> InfectionOverTimeS = new List<Tuple<int, int>>();

    public List<Vector2> InfectionLocations = new List<Vector2>();

    private void Awake()
    {
        VarManager = GameObject.Find("GameManager").GetComponent<VarManager>();
        Timer = GameObject.Find("GameManager").GetComponent<Timer>();
    }

    void Start()
    {
        totInfected = VarManager.totalInfected;

        // var InfectionOverTimeS = new List<(float, float)>();

        InfectionLocations.Add(GameObject.Find("corner1").transform.position);
        InfectionLocations.Add(GameObject.Find("corner2").transform.position);
        Debug.Log("InfectionLocationsStart:");
        Debug.Log("Found corner1: " + InfectionLocations[0]);
        Debug.Log("Found corner2: " + InfectionLocations[1]);

        mainPath = Application.dataPath + @"\Simulation_Data_Log\";
    }

    void Update()
    {
        totInfected = VarManager.totalInfected;

        if(!Timer.timerIsRunning)
        {
            DataCollection();
        }
    }

    private void OnDestroy()
    {
        //DataCollection();
    }

    //Function for creating and storing all Data that's been gathered in the Sim
    void DataCollection()
    {
        //InfectionOverTime Collection
        if (InfectionOverTimeS.Count > 0)
        {
            using (StreamWriter sw = new StreamWriter(mainPath + "InfectionOverTime.csv"))
            {
                sw.WriteLine("INFECTION OVER TIME - LOG" + "|" + " Total time(s):" + Timer.secondsPassed + " TOTAL INFECTIONS:" + totInfected + ",");
                sw.WriteLine("Time, Total Infections");
                sw.WriteLine("(0," + VarHolder.infectedPawnAmount + ")");
                for (int i = 0; i < InfectionOverTimeS.Count; i++)
                {
                    string s = InfectionOverTimeS[i].ToString();
                    s.Replace("(", "");
                    s.Replace(")", "");
                    sw.WriteLine(s);
                }
                Debug.Log("Infection Over Time Finished Collecting!");
            }
        }

        if (InfectionLocations.Count > 0)
        {
            using (StreamWriter sw = new StreamWriter(mainPath + "InfectionLocations.csv"))
            {
                sw.WriteLine("INFECTION LOCATIONS - LOG" + "|" + " Total time(s):" + Timer.secondsPassed + "TOTAL INFECTIONS:" + totInfected + ",");
                sw.WriteLine("X-Position, Y-Position");
                for (int i = 0; i < InfectionLocations.Count; i++)
                {
                    string s = InfectionLocations[i].ToString();
                    s.Replace("(", "");
                    s.Replace(")", "");
                    sw.WriteLine(s);
                }
                Debug.Log("Infection Locations Finished Collecting!");
            }
        }

        //TXT doc with all the simulation variables
        using (StreamWriter sw = new StreamWriter(mainPath + "SimulationVars.txt"))
        {
            sw.WriteLine("-|-Simulation Variables & Parameters TXT Document-|-");
            sw.WriteLine("--------------------------------------------------------");
            sw.WriteLine("This document contains all the variables and paramateres");
            sw.WriteLine("set by the user for testing.");
            sw.WriteLine("");
            sw.WriteLine("DISEASE VICTIM SUSCEPTIBILITY | Minimum val:" + VarHolder.minimumSusceptibility + " | Maximum val:" + VarHolder.maximumSusceptibility);
            sw.WriteLine("MASK WEARING PROBABILITY | Percentage:" + VarHolder.hasMaskChance);
            sw.WriteLine("BREATH RADIUS | Units:" + VarHolder.breathRadius);
            sw.WriteLine("BREATH INFECTION CHANCE | Percentage:" + VarHolder.areaInfectionChance);
            sw.WriteLine("COUGH CHANCE | Percentage:" + VarHolder.coughChance);
            sw.WriteLine("SNEEZE CHANCE | Percentage:" + VarHolder.sneezeChance);
            sw.WriteLine("AEROSOL CLOUD INFECTION CHANCE | Percentage:" + VarHolder.cloudInfectionChance);
            sw.WriteLine("--------------------------------------------------------");
            sw.WriteLine("TOTAL SIMULATION TIME | Hours:" + VarHolder.simHours + " Minutes:" + VarHolder.simMinutes);
            sw.WriteLine("TOTAL PAWNS IN PLAY:" + VarManager.totalPawns);
            sw.WriteLine("UN-INFECTED:" + VarHolder.uninfectedPawnAmount);
            sw.WriteLine("INFECTED:" + VarHolder.infectedPawnAmount);
            sw.WriteLine("VACCINATED:" + VarHolder.vaccinatedPawnAmount);
            sw.WriteLine("");
            sw.WriteLine("Percentage of Infected at Start: " + Convert.ToInt32((VarManager.infectedPawnAmount / VarManager.totalPawns) * 100) + "%");
            sw.WriteLine("Percentage of Vaccinated at Start: " + Convert.ToInt32((VarManager.vaccinatedPawnAmount / VarManager.totalPawns) * 100) + "%");
        }

    }
}
