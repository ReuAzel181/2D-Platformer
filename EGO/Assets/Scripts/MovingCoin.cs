using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCoin : MonoBehaviour
{
    private Vector2 initialPosition;
    public float speed = 1.0f;
    public float range = 1.0f;
    void Start()
    {
        // Store the initial position of the coin
        initialPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new Y position using a sine wave
        float newY = initialPosition.y + Mathf.Sin(Time.time * speed) * range;

        // Update the coin's position
        transform.position = new Vector2(transform.position.x, newY);
    }
}
