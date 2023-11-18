using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ValueText : MonoBehaviour
{
    private TextMeshProUGUI m_TextMeshProUGUI;

    [SerializeField] GameObject sliderObj;
    Slider slider;
    [SerializeField] UnityEvent<Slider> SetValue;

    private void Start()
    {
        slider = sliderObj.GetComponent<Slider>();
        m_TextMeshProUGUI = GetComponent<TextMeshProUGUI>();
        SetValue.Invoke(this.slider);
        OnValueChange(slider.value);
    }
    public void OnValueChange(float _value)
    {
        m_TextMeshProUGUI.text = _value.ToString();
    }
}
