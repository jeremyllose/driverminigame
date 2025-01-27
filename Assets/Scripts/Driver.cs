using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 100f;
    [SerializeField] float moveSpeed = 10f;

    private float originalMoveSpeed;
    [SerializeField] private float speedMultiplier = 1f;

    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //PART 1

        //Start is called before the first frame update

        //Update is called once per frame
    }

    // Update is called once per frame
    void Update()
    {
        // Regular movement logic
        float modifiedRotate = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float modifiedUpAndDown = Input.GetAxis("Vertical") * moveSpeed * speedMultiplier * Time.deltaTime;

        transform.Rotate(0, 0, -modifiedRotate);
        transform.Translate(0, modifiedUpAndDown, 0);
    }
    
    // Method to change speed multiplier
    public void SetSpeedMultiplier(float multiplier)
    {
        speedMultiplier = multiplier;
    }

    // Method to reset the speed multiplier to 1
    public void ResetSpeedMultiplier()
    {
        speedMultiplier = 1f;
    }
}