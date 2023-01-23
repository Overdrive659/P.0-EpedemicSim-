using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

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

    [SerializeField] private TextMeshProUGUI TimeText;

    public VarHolder VarHolder;

    // Start is called before the first frame update
    void Start()
    {
        TimeText = GameObject.Find("TimeText").GetComponent<TextMeshProUGUI>();

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

        string TimerEntry = TimeText.text;


    }

    public void OnDestroy()
    {
        
    }
}
