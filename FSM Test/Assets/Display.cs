using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    [SerializeField] Text Hours;
    [SerializeField] Text Minutes;
    [SerializeField] VarHolder VarHolder;
    // Start is called before the first frame update
    void Start()
    {
        Hours.text = Convert.ToString(VarHolder.simHours);
        Minutes.text = Convert.ToString(VarHolder.simMinutes);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
