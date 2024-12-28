using UnityEngine;

public class OverhangDetector : MonoBehaviour
{
    public LayerMask groundLayer;
    public float raycastDistance = 1.0f;
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;
    private bool isFalling;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        if (boxCollider == null || rb == null)
            Debug.LogError("Missing required components.");
    }

    void Update()
    {
        if (boxCollider == null || rb == null) return;

        // Get positions for raycasts (bottom center, left, and right)
        Vector2 centerOrigin = new Vector2(boxCollider.bounds.center.x, boxCollider.bounds.min.y - 0.01f);
        Vector2 leftOrigin = new Vector2(boxCollider.bounds.min.x, boxCollider.bounds.min.y - 0.01f);
        Vector2 rightOrigin = new Vector2(boxCollider.bounds.max.x, boxCollider.bounds.min.y - 0.01f);

        // Perform raycasts to check for ground directly below
        bool centerGrounded = Physics2D.Raycast(centerOrigin, Vector2.down, raycastDistance, groundLayer);
        bool leftGrounded = Physics2D.Raycast(leftOrigin, Vector2.down, raycastDistance, groundLayer);
        bool rightGrounded = Physics2D.Raycast(rightOrigin, Vector2.down, raycastDistance, groundLayer);

        // Debug ray visualization
        Debug.DrawRay(centerOrigin, Vector2.down * raycastDistance, centerGrounded ? Color.green : Color.red);
        Debug.DrawRay(leftOrigin, Vector2.down * raycastDistance, leftGrounded ? Color.green : Color.red);
        Debug.DrawRay(rightOrigin, Vector2.down * raycastDistance, rightGrounded ? Color.green : Color.red);

        // Count how many rays are grounded (center, left, right)
        int groundedCount = (centerGrounded ? 1 : 0) + (leftGrounded ? 1 : 0) + (rightGrounded ? 1 : 0);

        // Player is near edge and not grounded (i.e., falling condition)
        if (groundedCount < 2 && !isFalling)
        {
            HandleFall();
        }
        else if (groundedCount >= 2 && isFalling)
        {
            ResetFall();
        }
    }

    void HandleFall()
    {
        rb.gravityScale = 1f; // Enable gravity
        isFalling = true;

        // Enable Z index when falling (simulate the falling effect)
        transform.position = new Vector3(transform.position.x, transform.position.y, -1f); // Optional: adjust Z for falling effect
    }

    void ResetFall()
    {
        rb.gravityScale = 0f; // Optionally stop gravity if needed
        isFalling = false;

        // Reset Z index to 0 when the player hits the ground
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f); // Reset Z position after landing
    }
}
