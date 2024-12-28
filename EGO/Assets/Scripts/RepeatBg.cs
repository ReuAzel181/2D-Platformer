using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBg : MonoBehaviour
{
    public Renderer backgroundRenderer; // Renderer of the background material
    public GameObject player;           // Reference to the player GameObject
    public float scrollSpeed = 0.1f;    // Speed at which the background scrolls

    private Vector2 textureOffset;      // Tracks the texture offset

    void Update()
    {
        if (player == null || backgroundRenderer == null)
        {
            Debug.LogError("Player or background renderer not assigned!");
            return;
        }

        // Calculate texture offset based on player's position
        float offsetX = player.transform.position.x * scrollSpeed;
        float offsetY = player.transform.position.y * scrollSpeed;

        // Update the texture offset
        textureOffset = new Vector2(offsetX, offsetY);
        backgroundRenderer.material.mainTextureOffset = textureOffset;
    }
}
