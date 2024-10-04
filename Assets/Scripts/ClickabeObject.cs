using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ClickabeObject : MonoBehaviour
{
    private void OnMouseDown()
    {
        OnClick();
    }

    protected abstract void OnClick();
}
