using UnityEngine;

public class BackgroundFollow : MonoBehaviour {
    public Transform player; // Reference to the player's Transform
    public Vector2 offset = Vector2.zero; // Offset from the player (optional)

    void Update() {
        if (player != null) {
            // Update the background position to match the player's position, with optional offset
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
        }
    }
}
