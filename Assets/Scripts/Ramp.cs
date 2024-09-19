using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramp : MonoBehaviour
{   
    SurfaceEffector2D rampsurface;
    public SurfaceController surfaceController;
    float rampsurfacespeed;
    public float RampSurfaceSpeed()
    {
        return rampsurfacespeed;
    }
    public void Start()
    {
        rampsurface = GetComponent<SurfaceEffector2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        rampsurface.speed = surfaceController.FinalSpeed();  
    }

    public void RampSpeed()
    {

    }
}
