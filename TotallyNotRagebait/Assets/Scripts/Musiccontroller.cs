using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer instance;

    void Awake()
    {
        // Singleton pattern to prevent duplicates
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        // Keeps this object alive between scenes
        DontDestroyOnLoad(this.gameObject);
    }
}
