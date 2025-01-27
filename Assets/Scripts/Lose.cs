using Unity.VisualScripting;
using UnityEngine;

public class Lose : MonoBehaviour
{

    AudioManager audioManager;



    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static Lose Instance;

    // Reference to the win menu
    [SerializeField] private GameObject loseMenu;  // Make sure to assign this in the Inspector
    [SerializeField] private string playerTag = "Player"; // Make sure to define the player tag
    void Start()
    {

    }
    void Awake()
    {
        Instance = this;

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object has the "Player" tag
        if (collision.CompareTag(playerTag))
        {
            Debug.Log("Player reached the finish line!");
            // Activate the win menu
            loseMenu.SetActive(true);
            audioManager.PlaySFX(audioManager.DefeatSFX);
            Time.timeScale = 0;
        }
        
    }
}
