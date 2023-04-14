using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float jumpForce = 10f;
    public float moveSpeed = 5f;
    public int maxJumps = 2;

    private Rigidbody2D rb;
    private int jumpsRemaining;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpsRemaining = maxJumps;
    }

    private void Update()
    {
        // Check for jump input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        // Check for horizontal movement input
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        Move(horizontalInput);
    }

    private void Jump()
    {
        // Check if player is on the ground or has remaining jumps
        if (jumpsRemaining > 0)
        {
            // Apply jump force
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpsRemaining--;
        }
    }

    private void Move(float horizontalInput)
    {
        // Calculate new velocity based on input
        Vector2 velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        rb.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if player has landed on the ground
        if (collision.gameObject.tag == "Ground")
        {
            jumpsRemaining = maxJumps;
        }
    }
}
