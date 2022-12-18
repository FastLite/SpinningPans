using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public Scene LoadNewScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        var loadedScene = SceneManager.GetSceneByName(sceneName);
        return loadedScene;
        
    }

    public void LoadNewScene(int index)
    {
        SceneManager.LoadScene(index);

    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
