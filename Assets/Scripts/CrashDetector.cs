using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    
    [SerializeField] ParticleSystem groundParticles;
    [SerializeField] float delayTime = 2f;
    bool isSkating;
    bool isAdded = false;
    HingeJoint2D hj2;
    void Start() {
        
        groundParticles.Stop();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
            {
                OnRemoveComponent();
            }
    }
    /*private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Ground")
        {
            FindObjectOfType<PlayerController>().DisableControls();
            Debug.Log("Restart.");
            Invoke("ReloadScene",delayTime);
        }
        
    }*/

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            groundParticles.Play();
        }

        /*if(other.gameObject.CompareTag("halat") && isAdded == false)
        {
            isAdded = true;
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            HingeJoint2D hj = gameObject.AddComponent<HingeJoint2D>() as HingeJoint2D;
            hj2 = GetComponent<HingeJoint2D>();
            hj.connectedBody = rb;
        }*/
    }

    void OnCollisionExit2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            groundParticles.Stop();
        }
        
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
    void OnRemoveComponent()
    {
        Destroy(GetComponent<HingeJoint2D>());
    }
}
