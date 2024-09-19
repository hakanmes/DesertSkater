using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab1;
    public GameObject bulletPrefab2;
    public Animator anim;
    [SerializeField] Ammo ammoSlot;
    
    [SerializeField] AmmoType ammoType1;
    [SerializeField] AmmoType ammoType2;
    

    void Update()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            ShootAxe();
            
        }

        if(Input.GetKey(KeyCode.E))
        {
            ShootShruken();
            
        }
    }

    void ShootAxe()
    {
        if(ammoSlot.GetCurrentAmmo(ammoType1) > 0 && ammoSlot.GetCurrentAmmo(ammoType1) <=10)
        {
            Instantiate(bulletPrefab1, firePoint.position, firePoint.rotation);
            ammoSlot.ReduceCurrentAmmo(ammoType1);
            Anim();
        }
        
    }

    void ShootShruken()
    {
        if(ammoSlot.GetCurrentAmmo(ammoType2) > 0 && ammoSlot.GetCurrentAmmo(ammoType2) <=2)
        {
            Instantiate(bulletPrefab2, firePoint.position, firePoint.rotation);
            ammoSlot.ReduceCurrentAmmo(ammoType2);
            Anim();
        }
        
    }

    void Anim()
    {
        anim.Play("Fire");
    }
}
