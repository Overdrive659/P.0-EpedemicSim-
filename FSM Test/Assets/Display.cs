using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Unity.VisualScripting;

public class Display : MonoBehaviour
{
    [SerializeField] Text Hours;
    [SerializeField] Text Minutes;
    [SerializeField] VarHolder VarHolder;
    // Start is called before the first frame update

    string filename = string.Empty;

    public List<Tuple<int, int>> InfectionOverTimeS = new List<Tuple<int, int>>();

    void Start()
    {
        Hours.text = Convert.ToString(VarHolder.simHours);
        Minutes.text = Convert.ToString(VarHolder.simMinutes);

        for (int i = 0; i < 101; i++)
        {
            InfectionOverTimeS.Add(Tuple.Create(UnityEngine.Random.Range(0, 101), i));
        }

        filename = Application.dataPath + "/logs/" + "test.csv";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            real();
            Debug.Log("Wrote to CSV!");
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            using (StreamReader sr = new StreamReader(filename)) 
            {
                string s;
                do
                {
                    s = sr.ReadLine();
                    Debug.Log($"{s}");
                } 
                while(s != null);
            }

        }
    }

    public void real()
    {
        if(InfectionOverTimeS.Count > 0)
        {
            using(StreamWriter sw = new StreamWriter(filename))
            {
                for (int i = 0; i < InfectionOverTimeS.Count; i++)
                {
                    sw.WriteLine(InfectionOverTimeS[i]);
                }
            }
        }
    }
}
