using UnityEngine;

public class Collision : MonoBehaviour 
{
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log(other.gameObject.name);
    }
    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Missed");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
