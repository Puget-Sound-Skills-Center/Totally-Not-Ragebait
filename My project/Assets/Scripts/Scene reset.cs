using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class SceneResetter : MonoBehaviour
{
    public GameObject Player;
    // Call this method to reload the current scene
    public void RestartCurrentScene()
    {
        // Get the name of the currently active scene
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Load the scene with the retrieved name
        SceneManager.LoadScene(currentSceneName);

        // Optional: Ensure time scale is set to 1 in case it was frozen (e.g., on game over)
        Time.timeScale = 1f;
    }


    void Update()
    {
        if (Player.activeSelf == true)
        {

        }
        else
        {
         RestartCurrentScene();
        }
    }
}
