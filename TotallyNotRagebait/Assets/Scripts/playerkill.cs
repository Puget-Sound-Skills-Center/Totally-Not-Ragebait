using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Playerkill : MonoBehaviour
{
    public GameObject Player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger");
        if (other.CompareTag("Player"))
        {
            print("Kill trigger");
            Player.SetActive(false);

            

        }
    }
}
