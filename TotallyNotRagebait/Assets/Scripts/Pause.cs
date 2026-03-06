using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Link your Panel here in the Inspector
    private bool isPaused = false;

    void Start()
    {
        pauseMenuUI.SetActive(false); // Ensure menu is hidden at start
        Time.timeScale = 1f; // Ensure game starts unpaused
    }

    void Update()
    {
        // Use GetKeyDown to avoid multiple calls per frame
        if (Input.GetButtonDown("Pause"))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Resumes normal game speed
        isPaused = false;
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Pauses all time-based operations (physics, movement, animations)
        isPaused = true;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Crucial: Reset time scale before leaving
        SceneManager.LoadScene("MainMenuSceneName"); // Replace with your main menu scene name
    }
}