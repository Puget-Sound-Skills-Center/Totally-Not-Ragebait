using UnityEngine;
using UnityEngine.SceneManagement;

public class Clickscript : MonoBehaviour
{
    public int levelIndex;

    public void LoadLevel()
    {
        Debug.Log("Switching scene to " + levelIndex);
        SceneManager.LoadScene(levelIndex); 
    }
}
