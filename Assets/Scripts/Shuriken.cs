using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    public GameObject shuriken;
    public float launchForce;
    Rigidbody2D rb;
    public Transform shotPoint;
    // Update is called once per frame
    void Update()
    {
        Vector2 skaterposition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - skaterposition;
        transform.right = direction;

        if(Input.GetKey(KeyCode.Q))
        {
            Shoot();
        }


    }
    void Shoot()
    {
        GameObject newArrow = Instantiate(shuriken,shotPoint.position, shotPoint.rotation);
        newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;  
    }
}
