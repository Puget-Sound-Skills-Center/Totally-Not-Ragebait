using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Soundplayer : MonoBehaviour
{
    [SerializeField] AudioSource train;
    public GameObject Player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger");
        if (other.CompareTag("Player"))
        {
            print("Kill trigger");
            train.Play();

            

        }
        
    }
}
