using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    public void Play()
    {
        PlayerController.Instance.transform.position = Vector3.zero;
        SceneManager.LoadScene(sceneToLoad);
    }
    public void PlayClickSFX()
    {
        AudioManager.Instance.PlaySFX("Click");
    }
    public void Quit()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
