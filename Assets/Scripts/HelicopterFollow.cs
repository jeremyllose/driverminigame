using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HelicopterFollow : MonoBehaviour
{

    public GameObject player;
    public float speed;
    public float distanceBetween;
    private float distance;

    void Start()
    {

    }
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        if (distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

            // Get the player's forward direction
            Vector2 playerForward = player.transform.forward;

            // Calculate the angle between the enemy's direction and the player's forward direction
            float angle = Vector2.SignedAngle(direction, playerForward);

            // Rotate the enemy to face the player's direction
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
    }
}


