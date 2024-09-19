using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float length, startpos;
    public GameObject cam;
    public float parallaxEffect;
    
    

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x ;
        length = gameObject.GetComponent<SpriteRenderer>().bounds.size.x; 
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3 (startpos + dist, transform.position.y, transform.position.z);
        //transform.position = thingToFollow.transform.position + new Vector3(0,0,120);

        if(temp> startpos + length) startpos += length;
        else if(temp<startpos - length) startpos -= length;
    }
}
