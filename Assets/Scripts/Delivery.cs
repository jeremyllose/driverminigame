using System;
using UnityEngine;

public class Delivery : MonoBehaviour
{

 SpriteRenderer spriteRenderer;

 void Start()
 {
    spriteRenderer = GetComponent<SpriteRenderer>();
 }
   /* [SerializeField]
    Color32 hasPackageColor = new Color32 (1,1,1,1);

    [SerializeField]
    Color32 noPackageColor = new Color32 (1,1,1,1);

    */
    Boolean Haspackage = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   void OnTriggerEnter2D(Collider2D other)
{
    //Debug.Log("What was that?!");
    if (other.gameObject.tag == "Package" && !Haspackage == true)
    {
        Debug.Log("Delivery going");
        Haspackage = true;
        spriteRenderer.color = Color.red;

        Destroy(other.gameObject, 1);

    }



    if(other.gameObject.tag == "Customer" && Haspackage == true)
    {
        Debug.Log("Delivered successfully");
        Haspackage = false;
        spriteRenderer.color = Color.white;

    }
    if(other.gameObject.tag == "Customer" && Haspackage == false)
    {
        Debug.Log("WHERE'S MY PACKAGE!?");
    }




}
}