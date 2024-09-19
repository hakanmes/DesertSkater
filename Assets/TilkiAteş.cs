using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilkiAteş : MonoBehaviour
{
    public Transform firePoint;
    public GameObject arrow;
    public Animator anim;
    int numberofArrows = 1;
   private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            numberofArrows = 1;
            anim.SetTrigger("Tilki");
            Invoke("ShootArrow",0.8f);
        }
    }

    void ShootArrow()
    {
        if(numberofArrows == 1)
        {
            Instantiate(arrow, firePoint.position, firePoint.rotation);
            numberofArrows = 0;
        }
        
    }

}
