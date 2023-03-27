using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSimTime : MonoBehaviour
{
    [Range(1, 4)] public int simulationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        simulationSpeed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = simulationSpeed;
    }

    public int AdjustSpeed(int newSpeed)
    {
        simulationSpeed = newSpeed;
        return simulationSpeed;
    }
}
