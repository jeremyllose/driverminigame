using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  // For TextMeshPro

public class MainMenu : MonoBehaviour
{
    // Scene name for the game
    [SerializeField] private string gameSceneName = "GameScene";

    // References to UI elements
    [SerializeField] private GameObject mainMenuPanel; // Main menu UI
    [SerializeField] private GameObject aboutPanel;    // About UI
    [SerializeField] private TextMeshProUGUI aboutText; // About game description

    private void Start()
    {
        // Initially show only the main menu
        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(true);

        if (aboutPanel != null)
            aboutPanel.SetActive(false);
    }

    public void Play()
    {
        Debug.Log("Play button pressed, loading game...");
        SceneManager.LoadScene(gameSceneName); // Load the game scene
    }

    public void ShowAbout()
    {
        Debug.Log("About button pressed, showing about panel...");

        // Hide the main menu and show the about panel
        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(false);

        if (aboutPanel != null)
            aboutPanel.SetActive(true);

        if (aboutText != null)
            aboutText.text = "This is an exciting game where you navigate challenges and achieve victory!";
    }

    public void BackToMainMenu()
    {
        Debug.Log("Back button pressed, returning to main menu...");

        // Hide the about panel and show the main menu
        if (aboutPanel != null)
            aboutPanel.SetActive(false);

        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(true);
    }

    public void Quit()
    {
        Debug.Log("Quit button pressed, exiting application...");
        Application.Quit();
    }
}