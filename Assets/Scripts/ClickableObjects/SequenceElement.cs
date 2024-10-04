using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceElement : ClickabeObject
{
    public event Action<SequenceElement> OnElementChanged;

    protected override void OnClick()
    {
        OnElementChanged?.Invoke(this);
    }
}
