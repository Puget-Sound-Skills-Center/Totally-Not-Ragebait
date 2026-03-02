using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneResetter : MonoBehaviour
{
    public GameObject Player;
    private IEnumerator RestartCurrentScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(currentSceneName);

        Time.timeScale = 1f;
    }


    void Update()
    {
        if (Player.activeSelf == true)
        {

        }
        else
        {
            StartCoroutine(RestartCurrentScene());
        }
    }
}
