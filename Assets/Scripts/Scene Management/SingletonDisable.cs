using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingletonDisable : MonoBehaviour
{
    private string menuScene = "MainMenu";
    private GameObject target;

    private void Awake()
    {
        target = this.gameObject;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        bool shouldDisable = false;
        if (scene.name == menuScene)
        {
            shouldDisable = true;
        }
        target.SetActive(!shouldDisable);
    }
}
