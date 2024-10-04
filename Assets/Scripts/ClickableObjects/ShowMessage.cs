using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMessage : ClickabeObject
{
    [SerializeField] Canvas messageCanvas;
    [SerializeField] SpriteRenderer spriteRenderer;

    private void Start()
    {
        messageCanvas.enabled = false;
    }

    protected override void OnClick()
    {
        messageCanvas.enabled = true;
    }

    private void Update()
    {
        spriteRenderer.enabled = !messageCanvas.enabled;
    }
}
