using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderValueText : MonoBehaviour
{

    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI TextField;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }
    void Start()
    {
        UpdateText(_slider.value);
        _slider.onValueChanged.AddListener(UpdateText);
    }

    void UpdateText(float value)
    {
        TextField.text = _slider.value.ToString() + "%";
    }
}
