using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseCanvas : MonoBehaviour
{
    Button closeButton;
    [SerializeField] Canvas canvas;

    private void Start()
    {
        closeButton = GetComponent<Button>();
        closeButton.onClick.AddListener(Close);
    }

    private void Close()
    {
        canvas.enabled = false;
    }
}
