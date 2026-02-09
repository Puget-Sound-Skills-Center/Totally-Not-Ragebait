using Unity.VisualScripting;
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

    [Header("Directional Wall Bounce")]
    public float wallBounceForceX = 10f;
    public float wallBounceForceY = 12f;
    public float wallBounceCooldown = 0.15f;

    private float wallBounceTimer;
    private int wallDirection; // -1 = wall on left, 1 = wall on right

    private Rigidbody2D rb;
    private float horizontalInput;
    private bool isGrounded;
    private bool isTouchingWall;
    private bool isWallClinging;
    public GameObject Player;
    private bool ActiveSelf;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    [System.Obsolete]
    void Update()
    {
        wallBounceTimer -= Time.deltaTime;

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
        if (isTouchingWall)
        {
            // Wall is on the side the player is facing
            wallDirection = (int)Mathf.Sign(transform.localScale.x);
        }


        // Wall cling: player sticks if touching wall and in air
        isWallClinging = isTouchingWall && !isGrounded;

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
            else if (isTouchingWall && wallBounceTimer <= 0)
            {
                int bounceDir = -wallDirection; // ALWAYS away from wall

                rb.velocity = new Vector2(
                    bounceDir * wallBounceForceX,
                    wallBounceForceY
                );

                wallBounceTimer = wallBounceCooldown;

                // Flip player to face jump direction
                transform.localScale = new Vector3(bounceDir, 1, 1);
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