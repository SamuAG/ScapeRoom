using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : ClickabeObject
{
    private bool isOn = false;
    [SerializeField] private Transform leverTransform;
    private Quaternion initialRotation;
    public event Action OnLeverStateChanged;

    public bool IsOn { 
        get => isOn;
    }

    private void Start()
    {
        initialRotation = leverTransform.localRotation;
    }

    protected override void OnClick()
    {
        isOn = !isOn;
        // Esto esta hardcodeado y no es lo mejor
        leverTransform.localRotation = isOn ?  Quaternion.Euler(initialRotation.eulerAngles.x, initialRotation.eulerAngles.y, initialRotation.eulerAngles.z + 60) : initialRotation;
        OnLeverStateChanged?.Invoke();
    }
}
