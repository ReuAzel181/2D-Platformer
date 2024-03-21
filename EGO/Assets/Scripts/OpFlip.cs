using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpFlip : MonoBehaviour
{
    private SpriteRenderer sprite;
    private int currentIndex = 0;
    [SerializeField] private Transform[] flipPoints;
    [SerializeField] private float speed = 2f;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {


        Vector3 direction = flipPoints[currentIndex].position - transform.position;
        sprite.flipX = (direction.x < 0);

        if (Vector2.Distance(transform.position, flipPoints[currentIndex].position) < 0.1f)
        {
            currentIndex = (currentIndex + 1) % flipPoints.Length;
        }

        transform.position = Vector2.MoveTowards(transform.position, flipPoints[currentIndex].position, Time.deltaTime * speed);
    }
}
