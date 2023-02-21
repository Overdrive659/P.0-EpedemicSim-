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

    public int totInfected;

    string mainPath;

    // List for total Infections + Timestamp in seconds
    public List<Tuple<int, int>> InfectionOverTimeS = new List<Tuple<int, int>>();

    private void Awake()
    {
        VarManager = GameObject.Find("GameManager").GetComponent<VarManager>();
        Timer = GameObject.Find("GameManager").GetComponent<Timer>();
    }

    void Start()
    {
        totInfected = VarManager.totalInfected;

        // var InfectionOverTimeS = new List<(float, float)>();

        InfectionOverTimeS.Add(Tuple.Create(Timer.secondsPassed, totInfected));
        Debug.Log("Infection Over Time, 1st TUPLE:");
        Debug.Log(InfectionOverTimeS[0]);

        CreateStorage();
        mainPath = Application.dataPath + @"\Logs\Simulation_Data_Log\";
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

    void CreateStorage()
    {
        //Create File, with proper path, add text file to it.
        //Path
        string path = Application.dataPath + @"\Logs\Simulation_Data_Log\";

        Directory.CreateDirectory(path);
    }

    //Function for creating and storing all Data that's been gathered in the Sim
    void DataCollection()
    {
        //InfectionOverTime Collection
        if (InfectionOverTimeS.Count > 0)
        {
            using (TextWriter sw = new StreamWriter(mainPath + "InfectionOverTime.csv"))
            {
                sw.WriteLine("INFECTION OVER TIME, LOG" + "|" + "Total time(s):" + Timer.timeRemainingS + "TOTAL INFECTIONS:" + totInfected + ",");
                sw.WriteLine("Time, Total Infections");
                for (int i = 0; i < InfectionOverTimeS.Count; i++)
                {
                    sw.WriteLine(InfectionOverTimeS[i]);
                }
                sw.Close();
            }
        }
    }

    /*UNUSED, REFERENCE
    void CreateTextFile()
    {
        //Create the file
        string Basic_Infection_Log = Application.dataPath + @"Logs\Simulation_Data_Log\" + "InfectionOverTime.txt";

        //Add a heading inside the .txt file.
        File.WriteAllText(Basic_Infection_Log, "INFECTION OVER TIME, LOG" + "|" + "Total time(s):" + Timer.timeRemainingS + "TOTAL INFECTIONS:" + totInfected);
    }

    //UNUSED, REFERENCE
    void CreateTXT(string name)
    {
        name = Application.dataPath + @"Logs\Simulation_Data_Log\" + $"{name}.txt";
    }

    //UNUSED, REFERENCE
    void CreateCSV(string name)
    {
        name = Application.dataPath + @"Logs\Simulation_Data_Log\" + $"{name}.csv";
    }

    */
}
