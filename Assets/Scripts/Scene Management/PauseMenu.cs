using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    private bool isPaused = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; // Pause the game
        ActiveWeapon.Instance.DisableCombat(); // Disable combat controls
        isPaused = true;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; // Resume the game
        ActiveWeapon.Instance.EnableCombat(); // Enable combat controls
        isPaused = false;
    }
    public void Menu()
    {
        // Load the main menu scene
        Time.timeScale = 1f; // Ensure time scale is reset when returning to menu
        pauseMenu.SetActive(false);
        isPaused = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void PlayClickSFX()
    {
        AudioManager.Instance.PlaySFX("Click");
    }
}
