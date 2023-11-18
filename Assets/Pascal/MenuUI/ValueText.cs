using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class ValueText : MonoBehaviour
{
    private TextMeshProUGUI m_TextMeshProUGUI;

    Slider slider;
    [SerializeField] GameObject sliderObj;
    [SerializeField] UnityEvent<Slider> SetValue;

    private void Awake()
    {
        slider = sliderObj.GetComponent<Slider>();
    }
    private void Start()
    {
        SetValue.Invoke(this.slider);
        m_TextMeshProUGUI = GetComponent<TextMeshProUGUI>();
        OnValueChange(slider.value);
    }
    public void OnValueChange(float _value)
    {
        m_TextMeshProUGUI.text = _value.ToString();
    }
}
