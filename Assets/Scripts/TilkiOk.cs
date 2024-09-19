using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilkiOk : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    

    // Update is called once per frame
    void Update()
    {
        rb.velocity = -transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        //Agac agac = hitInfo.GetComponent<Agac>();
        
        
        /*if(hitInfo.tag == "agac" && agac.isCut == false)
        {
            agac.Anim();
        }*/
        if(enemy != null)
        {
            enemy.TakeDamage(3);
        }

        
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player") 
        {
            Destroy(gameObject);
        }
    }
}
