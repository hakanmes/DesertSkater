using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agac : MonoBehaviour
{
    public Animator animator;

    public bool isCut = false;
    public void Anim()
    {
        animator.SetTrigger("Kırılma");
    }

    void OnTriggerEnter2D(Collider2D other)  
    {
        if(other.tag == "Balta" && isCut == false)
        {
            Anim();
            isCut = true;
        }

        if(other.tag == "shuriken" )
        {
           Destroy(other.gameObject);
        }
        //isCut = true;
    }
}
