using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 100f;
    [SerializeField] float moveSpeed = 10f;

    private float originalMoveSpeed;
    [SerializeField] private float speedMultiplier = 1f;
    [SerializeField] private float carSoundVolume = 0.5f;
    AudioManager audioManager;
    private bool isMoving = false;
    private AudioSource carAudioSource;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        // Create a new AudioSource for the car sound
        carAudioSource = gameObject.AddComponent<AudioSource>();
        carAudioSource.clip = audioManager.CarSFX; // Assign the car sound
        carAudioSource.loop = true;               // Make it loop
        carAudioSource.playOnAwake = false;       // Don’t play it immediately
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

        // Determine if the car is moving
        if (Mathf.Abs(modifiedRotate) > 0 || Mathf.Abs(modifiedUpAndDown) > 0)
        {
            // If the car is moving, play the car sound
            if (!carAudioSource.isPlaying)
            {
                carAudioSource.Play();
            }

            // Adjust pitch based on speed
            float speed = Mathf.Abs(modifiedUpAndDown);
            carAudioSource.pitch = Mathf.Lerp(1f, 2f, speed / moveSpeed); // Smooth pitch adjustment
        }
        else
        {
            // Stop the sound if the car is not moving
            if (carAudioSource.isPlaying)
            {
                carAudioSource.Stop();
            }
        }
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