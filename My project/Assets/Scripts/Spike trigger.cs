using UnityEngine;

public class Animationplayer : MonoBehaviour
{
    [SerializeField] private Animator targetAnimator;
    [SerializeField] private string triggerName = "PlayAnim";


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered by: " + other.name);
        Debug.Log("broken");

        if (other.CompareTag("Player"))
        {
            Debug.Log("something ain't workin");
            targetAnimator.SetTrigger(triggerName);
        }
    
    }
}
