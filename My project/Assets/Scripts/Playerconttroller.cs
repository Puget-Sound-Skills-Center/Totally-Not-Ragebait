using UnityEngine;

public class WallClingPlayer : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;
    public float jumpForce = 10f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    [Header("Wall Check")]
    public Transform wallCheck;
    public float wallCheckRadius = 0.2f;
    public LayerMask wallLayer;

    [Header("Wall Jump")]
    public float wallJumpForceX = 8f;
    public float wallJumpForceY = 10f;

    private Rigidbody2D rb;
    private float horizontalInput;
    private bool isGrounded;
    private bool isTouchingWall;
    private bool isWallClinging;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    [System.Obsolete]
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        // Flip player to face movement
        if (horizontalInput != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(horizontalInput), 1, 1);
        }

        // Ground check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Wall check
        isTouchingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, wallLayer);

        // Wall cling: player sticks if touching wall and in air
        isWallClinging = isTouchingWall && !isGrounded && horizontalInput == Mathf.Sign(transform.localScale.x);

        if (isWallClinging)
        {
            rb.velocity = Vector2.zero; // freeze player on wall
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            else if (isWallClinging)
            {
                float jumpDir = -Mathf.Sign(transform.localScale.x); // push away from wall
                rb.velocity = new Vector2(jumpDir * wallJumpForceX, wallJumpForceY);

                // Optional: flip player away from wall
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), 1, 1);
            }
        }
    }

    [System.Obsolete]
    void FixedUpdate()
    {
        // Horizontal movement only if not clinging
        if (!isWallClinging)
        {
            rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        }
    }
}
