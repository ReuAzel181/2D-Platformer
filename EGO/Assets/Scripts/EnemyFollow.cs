using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float maxFollowRange;
    private SpriteRenderer sprite;
    private Transform target;
    public float speed;
    private Vector3 lastPosition;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        lastPosition = transform.position;
    }

    void Update()
    {
        MoveTowardsTarget();
        FlipSprite();
        lastPosition = transform.position;
    }

    void MoveTowardsTarget()
    {
    float distanceToTarget = Vector2.Distance(transform.position, target.position);
    if (distanceToTarget <= maxFollowRange)
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
    }

    void FlipSprite()
    {
        if (transform.position.x < lastPosition.x)
        {
            sprite.flipX = false; // Enemy is moving left
        }
        else if (transform.position.x > lastPosition.x)
        {
            sprite.flipX = true; // Enemy is moving right
        }
    }
}
