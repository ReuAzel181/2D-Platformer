using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private bool isDead = false;

    public void Die()
    {
        isDead = true;
        // Play death animation or handle death logic
    }

    public bool IsDead()
    {
        return isDead;
    }
}
