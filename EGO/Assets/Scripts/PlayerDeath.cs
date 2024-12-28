using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Death : MonoBehaviour
{
    [SerializeField] private AudioSource deathSoundEffect;
    private Rigidbody2D rb;
    private Animator anim;
    private PlayerMovement playerMovement;
    [SerializeField] private float respawnDelay = 2f;  // Adjust this to match your animation length
    [SerializeField] private float fallThreshold = -10f;  // Threshold for falling death
    [SerializeField] private float fallVelocityThreshold = -15f;  // Velocity threshold for falling death
    private ItemCollector itemCollector;  // Reference to the ItemCollector script

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();
        itemCollector = GetComponent<ItemCollector>();  // Get the ItemCollector component
    }

    private void Update()
    {
        // Check if player has fallen below the threshold and is falling fast enough to consider it a death
        if (transform.position.y < fallThreshold && rb.velocity.y < fallVelocityThreshold)
        {
            if (!deathSoundEffect.isPlaying)
            {
                deathSoundEffect.Play();
            }
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("blueOp") || collision.gameObject.CompareTag("Spike") || collision.gameObject.CompareTag("HSnail"))
        {
            if (!deathSoundEffect.isPlaying)
            {
                deathSoundEffect.Play();
            }
            Die();
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");

        // Disable the PlayerMovement component
        if (playerMovement != null)
        {
            playerMovement.enabled = false;
            Debug.Log("PlayerMovement script disabled");
        }
        else
        {
            Debug.LogError("PlayerMovement script not found");
        }

        Debug.Log("Death animation triggered");
        StartCoroutine(ShowGameOverScreenAfterDelay());
    }

    private IEnumerator ShowGameOverScreenAfterDelay()
    {
        yield return new WaitForSeconds(respawnDelay);  // Wait for the death animation to complete
        Debug.Log("Loading Game Over scene after delay");

        // Pass the coin count to the game over screen
        int coinsCollected = itemCollector.GetCoinCount();
        PlayerPrefs.SetInt("CoinsCollected", coinsCollected);  // Store the coin count in PlayerPrefs

        // Load the game over scene
        SceneManager.LoadScene(2);
    }
}
