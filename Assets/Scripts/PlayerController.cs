using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    
    // Start is called before the first frame update
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;
    public Animator animator;
    public float jumpSpeed = 8f;
    Rigidbody2D rb2d;
    SurfaceController surfaceEffector2D;

    float curSpeed = 0.5f;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public LayerMask poleLayer;
    public LayerMask rampLayer;
    bool isTouchingGround;
    bool isTouchingPole;
    bool isTouchingRamp;
    public bool isBend = false;
    public bool IsTouchingGround()
    {
        return isTouchingGround;
    }
    
    //public Sprite Speedy;

    private Collider2D collider;
    bool canMove = true;

    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        surfaceEffector2D = GetComponent<SurfaceController>();
        groundLayer = LayerMask.GetMask("Ground");
        poleLayer = LayerMask.GetMask("Pole");
        rampLayer = LayerMask.GetMask("Ramp");

    
    }

    // Update is called once per frame
    public void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,groundLayer);
        isTouchingPole = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,poleLayer);
        isTouchingRamp = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,rampLayer);
        if(canMove)
        {
            RotatePlayer();
            //RespondToBoost();
        }

        if(isTouchingGround)
        {
            Anim();
            
            
            /*Destroy(this.GetComponent<PolygonCollider2D>());
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Speedy;
            this.gameObject.AddComponent<PolygonCollider2D>();*/
        }
        /*if(!isTouchingGround)
        {
            surfaceEffector2D.isSki = false;
        }*/
        
    }
    public void DisableControls()
    {
        canMove = false;
    }
   /* void RespondToBoost()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }*/

    private void RotatePlayer()
    {
        
        if(Input.GetButtonDown("Jump") && isTouchingGround )
        {
            jumpSpeed = 15f;
            rb2d.velocity = new Vector2(rb2d.velocity.x,jumpSpeed);
        }
        if(Input.GetButtonDown("Jump") && isTouchingRamp )
        {
            jumpSpeed = 30f;
            rb2d.velocity = new Vector2(rb2d.velocity.x,jumpSpeed);
        }
        if(Input.GetButtonDown("Jump") && isTouchingPole )
        {
            jumpSpeed = 15f;
            rb2d.velocity = new Vector2(rb2d.velocity.x,jumpSpeed);
        }
        
        

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }

    public void Anim()
    {
        animator.SetTrigger("Ride");
        if(Input.GetKey(KeyCode.LeftControl))
        {

            animator.Play("Bend");

        }
    }
}
