using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSlider : MonoBehaviour
{
    [SerializeField] private Slider timeSlider;
    [SerializeField] private ChangeSimTime simTime;


    // Start is called before the first frame update
    void Start()
    {
        timeSlider.onValueChanged.AddListener(delegate { simTime.AdjustSpeed((int)timeSlider.value); }) ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
