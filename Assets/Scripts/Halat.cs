using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Halat : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)  
    {
        if(other.tag == "shuriken")
        {
            Destroy(gameObject);
        }
        //isCut = true;
    }
}