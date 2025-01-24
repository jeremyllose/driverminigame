using UnityEngine;

public class SimpleFollowCamera : MonoBehaviour
{
    [SerializeField]
    GameObject thingToFollow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    void LateUpdate()
    {
        transform.position = thingToFollow.transform.position + new Vector3(0, 0, -10);
        //Position ni Camera = Position Player
        // [x,y,z] = [x,y,z]
        
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
