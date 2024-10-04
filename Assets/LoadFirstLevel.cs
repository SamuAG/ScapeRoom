using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFirstLevel : MonoBehaviour
{
    [SerializeField] List<int> levels = new List<int>();
    void Start()
    {
        foreach (var level in levels)
            SceneManager.LoadSceneAsync(level, LoadSceneMode.Additive);
    }
}
