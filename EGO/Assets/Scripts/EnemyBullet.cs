using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBullet : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    public float maxDistance = 20f; 
    private Vector2 startPosition;
    private Animator anim;
    [SerializeField] private AudioSource deathSoundEffect;


    private bool playerHit = false;
    [SerializeField] private float respawnDelay = 2f;

void Start()
{
    rb = GetComponent<Rigidbody2D>();
    player = GameObject.FindGameObjectWithTag("Player");
    if (player == null)
    {
        Debug.LogError("Player not found!");
        return;
    }
    anim = player.GetComponent<Animator>(); // Get the Animator component from the player

    if (anim == null)
    {
        Debug.LogError("Animator component not found on player!");
    }

    Vector3 direction = player.transform.position - transform.position;
    rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

    float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
    transform.rotation = Quaternion.Euler(0, 0, rot);
    
    startPosition = transform.position;
}

    void Update()   
    {
        if (!playerHit)
        {
            float distance = Vector2.Distance(startPosition, transform.position);

            if (distance >= maxDistance)
            {
                Destroy(gameObject);
            }
        }
    }
void OnTriggerEnter2D(Collider2D other)
{
    if (!playerHit && other.gameObject.CompareTag("Player"))
    {
        playerHit = true; // Set playerHit to true to prevent further actions related to the player

        if (deathSoundEffect != null)
        {
            deathSoundEffect.Play(); // Play the death sound
        }

        Die(); // Call the Die method
    }
    else if (other.gameObject.CompareTag("Tilemap"))
    {
        Destroy(gameObject); // Destroy the bullet if it hits a tilemap
    }
}
    
private void Die()
{
    rb.bodyType = RigidbodyType2D.Static;
    if (anim != null)
    {
        anim.SetTrigger("death");
        // Add a check to stop attacking if player is in death animation
        // Assuming 'attack' is the trigger parameter in the animator
        anim.ResetTrigger("attack");
    }
    else
    {
        Debug.LogError("Animator component is null!");
    }
    StartCoroutine(RestartAfterDelay());
}

    private IEnumerator RestartAfterDelay()
    {
        Debug.Log("Waiting for death animation to complete...");
        yield return new WaitForSeconds(respawnDelay);  // Wait for the death animation to complete
        Debug.Log("Restarting scene after delay");
        SceneManager.LoadScene(2);
    }
}
