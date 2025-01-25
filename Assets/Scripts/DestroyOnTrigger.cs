using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object has the specified tag
        if (collision.gameObject.CompareTag(playerTag))
        {
            Debug.Log("Player collided and destroyed: " + gameObject.name);

            // Destroy the object this script is attached to
            Destroy(gameObject, 0.5f); // Optional delay of 1 second
        }
    }
}