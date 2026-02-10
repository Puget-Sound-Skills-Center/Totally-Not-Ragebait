using UnityEngine;

public class Animationplayer : MonoBehaviour
{
    [SerializeField] private Animator targetAnimator;
    [SerializeField] private string triggerName = "PlayAnim";

    private bool hasPlayed = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("broken");
        if (hasPlayed) return;

        if (other.CompareTag("Player"))
        {
            targetAnimator.SetTrigger(triggerName);
            hasPlayed = true;
        }
    }
}
