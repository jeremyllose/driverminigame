using UnityEngine;
using UnityEngine.UI;
public class MusicManager : MonoBehaviour
{
    public AudioSource MenuMusic; 
    public AudioSource GameMusic; 
    public GameObject playButton; // Drag and drop your Play button GameObject here in the Inspector

    void Start()
    {
        // Stop game music initially
        GameMusic.Stop(); 

        // Listen for button click event
        playButton.GetComponent<Button>().onClick.AddListener(StartGame); 
    }

    void StartGame()
    {
        // Stop main menu music
        MenuMusic.Stop(); 

        // Play game music
        GameMusic.Play(); 
    }
}