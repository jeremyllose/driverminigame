using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private float slowDuration = 2f; // Duration to slow the player
    [SerializeField] private float speedMultiplier = 0.5f; // Speed multiplier (e.g., 0.5 reduces speed by half)

    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            Debug.Log("Player collided with: " + gameObject.name);

            // Destroy the object this script is attached to after 0.5 seconds
            Destroy(gameObject, 0.5f);
            audioManager.PlaySFX(audioManager.PowerUpSFX);

            // Get the Driver component from the player and slow down the player
            Driver driver = collision.gameObject.GetComponent<Driver>();
            if (driver != null)
            {
                Debug.Log("Slowing down the player...");

                // Set the player's speed multiplier
                driver.SetSpeedMultiplier(speedMultiplier);

                // Start the coroutine to restore speed after the slowDuration
                StartCoroutine(RestoreSpeedAfterDelay(driver));
            }
        }
    }

    // Coroutine to restore the original speed multiplier of the player after the slowDuration
    private System.Collections.IEnumerator RestoreSpeedAfterDelay(Driver driver)
    {
        // Wait for the specified slowDuration before restoring speed
        yield return new WaitForSeconds(slowDuration);

        // Check if the Driver component still exists and restore the speed
        if (driver != null)
        {
            driver.ResetSpeedMultiplier();
            Debug.Log("Player's speed restored!");
        }
        else
        {
            Debug.LogWarning("Driver component no longer exists; cannot restore speed.");
        }
    }
}
