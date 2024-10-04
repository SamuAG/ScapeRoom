using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPosition : ClickabeObject
{
    [SerializeField] GameManager gM;
    public Transform targetPosition;

    protected override void OnClick()
    {
        gM.Player.transform.position = targetPosition.position;
    }
}
