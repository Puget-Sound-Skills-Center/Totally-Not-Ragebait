using UnityEngine;

public class TriggerMoveToPosition2Ddelay : MonoBehaviour
{
    [Header("Object To Move")]
    public Transform objectToMove;

    [Header("Target Position")]
    public Vector2 targetPosition;

    [Header("Settings")]
    public bool moveInstantly = true;
    public float moveSpeed = 3f;

    private bool shouldMove = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
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
}
