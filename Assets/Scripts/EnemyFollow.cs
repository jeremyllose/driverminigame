using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float distanceBetween;
    private float distance;

    void Update()
    {
        // Calculate the distance and direction to the player
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        if (distance < distanceBetween)
        {
            // Move the enemy towards the player
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

            // Calculate the angle to rotate towards the player
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Adjust the angle if the sprite's forward direction isn't along the X-axis
            angle -= 90f; // Adjust as needed depending on your sprite's orientation

            // Apply rotation to the enemy to face the player
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
