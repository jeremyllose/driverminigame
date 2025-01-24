using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float LeftRight;
    [SerializeField] float UpDown;
    [SerializeField] float RotateLR;
    [SerializeField] float RotateUD;
    [SerializeField] float steerSpeed = 100f;
    [SerializeField] float moveSpeed = 10f;

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
        // transform.Rotate(RotateLR,RotateUD,0);
        //  transform.Translate(LeftRight,UpDown,0);

        float modifiedRotate = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float modifiedUpAndDown = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        // transform.Translate(x,y,0);

        transform.Rotate(0,0, -modifiedRotate);
        transform.Translate(0, modifiedUpAndDown, 0);

    }
}
