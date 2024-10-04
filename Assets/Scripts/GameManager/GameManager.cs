using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameManager", menuName = "GameManager")]
public class GameManager : ScriptableObject
{
    [NonSerialized] GameObject player;

    public GameObject Player { get => player; set => player = value; }
}
