using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class ObjectXRotationHandler : MonoBehaviour
{

    [SerializeField] Transform ObjectToControl;

    [SerializeField] Slider slider;
    void OnEnable()
    {

        slider.onValueChanged.AddListener(UpdateRotation);
    }

    void OnDisable()
    {
        slider.onValueChanged.RemoveListener(UpdateRotation);

    }

    private void UpdateRotation(float arg0)
    {
        ObjectToControl.rotation = Quaternion.Euler(new Vector3(arg0, ObjectToControl.rotation.eulerAngles.y, ObjectToControl.rotation.eulerAngles.z));
    }
}
