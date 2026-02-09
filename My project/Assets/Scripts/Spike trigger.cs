using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    // Reference to the Animator component you want to control
    public Animator targetAnimator;

    // The name of the Trigger/Bool parameter in the Animator
    public string animationParameterName;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Set the Animator parameter to activate the transition
            // Use SetTrigger() for a Trigger parameter or SetBool(true) for a Bool parameter
            targetAnimator.SetTrigger(animationParameterName);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Optional: If using a Bool and you want the animation to stop/reverse on exit
        if (other.CompareTag("Player"))
        {
            // targetAnimator.SetBool(animationParameterName, false);
        }
    }
}
