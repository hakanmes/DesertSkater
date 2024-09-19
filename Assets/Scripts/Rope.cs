using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public Rigidbody2D hook;
    public GameObject linkPrefab;
    public int links = 7;   
    void Start()
    {
        GenerateRope();
    }

    void GenerateRope()
    {
        Rigidbody2D previousRB = hook;
        for(int i = 0; i<links; i++)
        {
           GameObject link = Instantiate(linkPrefab,transform.position, transform.rotation);
           HingeJoint2D joint = link.GetComponent<HingeJoint2D>();
           joint.connectedBody = previousRB;

           previousRB = link.GetComponent<Rigidbody2D>();
        }
    }
}
