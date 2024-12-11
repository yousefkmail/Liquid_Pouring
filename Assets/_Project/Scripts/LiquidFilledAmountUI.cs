using System;
using LiquidSimulation.Core;
using UnityEngine;
using UnityEngine.UI;

public class LiquidFilledAmountUI : MonoBehaviour
{

    [SerializeField] LiquidBeaker ObjectToControl;

    [SerializeField] Slider slider;

    void OnEnable()
    {
        slider.onValueChanged.AddListener(UpdateFilledAmount);
    }

    private void UpdateFilledAmount(float arg0)
    {
        ObjectToControl.FilledAmount = arg0;
    }

    void Update()
    {

        slider.value = ObjectToControl.FilledAmount;

    }

    void OnDisable()
    {
        slider.onValueChanged.RemoveListener(UpdateFilledAmount);

    }



}
