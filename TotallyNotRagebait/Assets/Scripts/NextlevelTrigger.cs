using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove_Ref : MonoBehaviour
{
    public string Levelindex;

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger");
        if (other.CompareTag("Player"))
        {
            print("playerTrigger");
            Debug.Log("Switching scene to " + Levelindex);
            SceneManager.LoadScene(int.Parse(Levelindex));

        }
    }
}
