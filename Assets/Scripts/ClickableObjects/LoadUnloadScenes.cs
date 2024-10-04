using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadUnloadScenes : ClickabeObject
{
    [SerializeField] private List<int> scenesToLoad;
    [SerializeField] private List<int> scenesToUnload;

    protected override void OnClick()
    {
        foreach (var sceneIndex in scenesToLoad)
        {
            SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
        }

        foreach (var sceneIndex in scenesToUnload)
        {
            SceneManager.UnloadSceneAsync(sceneIndex);
        }
    }
}
