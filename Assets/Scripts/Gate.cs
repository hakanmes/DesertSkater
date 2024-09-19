using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    GameObject lights;
    void Start()
    {
        lights = GameObject.FindGameObjectWithTag("Sun");
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            lights.SetActive(false);
        }
    }
}
