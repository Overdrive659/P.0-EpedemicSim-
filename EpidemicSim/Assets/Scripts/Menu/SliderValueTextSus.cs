using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderValueTextSus : MonoBehaviour
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
        float tmp = Mathf.Round(value * 100f) / 100f;
        TextField.text = tmp.ToString();
    }
}
