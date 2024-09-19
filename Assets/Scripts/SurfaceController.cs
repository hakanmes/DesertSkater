using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceController : MonoBehaviour
{
    float curSpeed=.02f;
    float downSpeed = .01f;
    float finalSpeed; 

    public float FinalSpeed()
    {
        return finalSpeed;
    }
    SurfaceEffector2D surfaceEffector2D;
    [SerializeField] PlayerController player;
    
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        surfaceEffector2D = GetComponent<SurfaceEffector2D>();
    }
    void Update()
    {
        finalSpeed = surfaceEffector2D.speed;
        //Debug.Log(finalSpeed);
        //Debug.Log(player.IsTouchingGround());
        SurfaceSpeed();
    }

    public void SurfaceSpeed()
    {
        if(player.IsTouchingGround())
        {
            if(surfaceEffector2D.speed <= 40)
            {
                surfaceEffector2D.speed += curSpeed;
            }

        }
        if(!player.IsTouchingGround())
        {
            surfaceEffector2D.speed -= downSpeed;
        }
    }

    
}
