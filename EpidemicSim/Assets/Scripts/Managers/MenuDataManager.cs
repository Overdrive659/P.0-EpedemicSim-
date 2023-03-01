using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Runtime.CompilerServices;
using System.Diagnostics;

public class MenuDataManager : MonoBehaviour
{
    Slider BreathRadiusSlider;
    Slider AreaInfectionSlider;
    Slider CoughSlider;
    Slider SneezeSlider;
    Slider AerosolSlider;
    Slider MaskSlider;
    Slider MaxSusSlider;
    Slider MinSusSlider;

    [SerializeField] private InputField TimeField;

    [SerializeField] private InputField DefaultPawnField;
    [SerializeField] private InputField InfectedPawnField;
    [SerializeField] private InputField VaccinatedPawnField;

    public VarHolder VarHolder;

    // Start is called before the first frame update
    void Start()
    {
        BreathRadiusSlider = GameObject.Find("BreathRadiusSlider").GetComponent<Slider>();
        AreaInfectionSlider = GameObject.Find("AreaInfectionSlider").GetComponent<Slider>();
        CoughSlider = GameObject.Find("CoughSlider").GetComponent<Slider>();
        SneezeSlider = GameObject.Find("SneezeSlider").GetComponent<Slider>();
        AerosolSlider = GameObject.Find("AerosolSlider").GetComponent<Slider>();
        MaskSlider = GameObject.Find("MaskSlider").GetComponent<Slider>();
        MaxSusSlider = GameObject.Find("MaxSusSlider").GetComponent<Slider>();
        MinSusSlider = GameObject.Find("MinSusSlider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        VarHolder.breathRadius = Convert.ToInt32(BreathRadiusSlider.value);
        VarHolder.areaInfectionChance = Convert.ToInt32(AreaInfectionSlider.value);
        VarHolder.coughChance = Convert.ToInt32(CoughSlider.value);
        VarHolder.sneezeChance = Convert.ToInt32(SneezeSlider.value);
        VarHolder.cloudInfectionChance = Convert.ToInt32(AerosolSlider.value);
        VarHolder.hasMaskChance = Convert.ToInt32(MaskSlider.value);
        VarHolder.maximumSusceptibility = MaxSusSlider.value;
        VarHolder.minimumSusceptibility = MinSusSlider.value;
    }

    public void OnDestroy()
    {
        if(TimeField.text != null)
        {
            string[] timeArray = TimeField.text.Split(':');

            if(timeArray.Length > 0 )
            {
                UnityEngine.Debug.Log(timeArray[0] + " Hours");
                UnityEngine.Debug.Log(timeArray[1] + " Minutes");
                VarHolder.simHours = int.Parse(timeArray[0]);
                VarHolder.simMinutes = int.Parse(timeArray[1]);
            }
        }

        bool IsNull1 = Int32.TryParse(DefaultPawnField.text, out int tmp1);
        bool IsNull2 = Int32.TryParse(InfectedPawnField.text, out int tmp2);
        bool IsNull3 = Int32.TryParse(VaccinatedPawnField.text, out int tmp3);

        if (IsNull1)
        {
            VarHolder.uninfectedPawnAmount = tmp1;
        }
        else
        {
            VarHolder.uninfectedPawnAmount = null;
        }

        if (IsNull2)
        {
            VarHolder.infectedPawnAmount = tmp2;
        }
        else
        {
            VarHolder.infectedPawnAmount = null;
        }

        if (IsNull3)
        {
            VarHolder.vaccinatedPawnAmount = tmp3;
        }
        else
        {
            VarHolder.vaccinatedPawnAmount = null;
        }



    }
}
