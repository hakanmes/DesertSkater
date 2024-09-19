using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rings : MonoBehaviour
{
    [SerializeField] ParticleSystem successParticle;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        { 
            Debug.Log("Added");
            successParticle.Play();
        }
        
    }
}
