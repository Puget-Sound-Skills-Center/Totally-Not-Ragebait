using System.Collections;
using UnityEngine;

public class TriggerMoveToPosition2D : MonoBehaviour
{
    [Header("Object To Move")]
    public Transform objectToMove;

    [Header("Target Position")]
    public Vector2 targetPosition;

    [Header("Settings")]
    public bool moveInstantly = true;
    public float moveSpeed = 3f;

    private bool shouldMove = false;
   
    [Header("Delay")]
    public float delayBeforeMove = 1f;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DelayedMove());
        }
    }


    private void Update()
    {
        if (shouldMove)
        {
            objectToMove.position = Vector2.MoveTowards(
                objectToMove.position,
                targetPosition,
                moveSpeed * Time.deltaTime
            );

            if ((Vector2)objectToMove.position == targetPosition)
            {
                shouldMove = false;
            }
        }
 
    }
    private IEnumerator DelayedMove()
    {
        yield return new WaitForSeconds(delayBeforeMove);

        if (moveInstantly)
        {
            objectToMove.position = targetPosition;
        }
        else
        {
            shouldMove = true;
        }
    }

}
