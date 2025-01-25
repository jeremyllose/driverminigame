using UnityEngine;

public class Boundary : MonoBehaviour
{
    [SerializeField] private float slowDownFactor = 0.5f; // Factor to reduce velocity (0.5 = 50% slower)

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object has a Rigidbody2D
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            // Reduce the velocity of the object
            rb.linearVelocity *= slowDownFactor;

            // Optional: Clamp the velocity to prevent it from becoming too slow
            if (rb.linearVelocity.magnitude < 0.1f)
            {
                rb.linearVelocity = Vector2.zero; // Stop the object if velocity is too small
            }
        }
    }
}
