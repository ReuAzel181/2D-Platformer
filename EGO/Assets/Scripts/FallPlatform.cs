using System.Collections;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private bool playerOnPlatform;
    private Rigidbody2D rb;

    public float fallDelay = 1f;
    public float fallSpeed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (playerOnPlatform)
        {
            StartCoroutine(FallAfterDelay());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnPlatform = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnPlatform = false;
        }
    }

    IEnumerator FallAfterDelay()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.velocity = Vector2.down * fallSpeed;
        Destroy(gameObject, 2f); // Destroy the platform after 2 seconds of falling
    }
}
