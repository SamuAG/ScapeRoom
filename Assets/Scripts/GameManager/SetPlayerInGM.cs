using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerInGM : MonoBehaviour
{
    [SerializeField] GameManager gM;

    void Start()
    {
        gM.Player = this.gameObject;
    }
}
