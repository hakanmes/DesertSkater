using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health = 10;

    public Animator animator;

    public GameObject deathEffect;
    // Start is called before the first frame update
    public void TakeDamage(int damage)
    {

        health -= damage;
        if(health <= 0)
        {
            Die();
        }
        Attack();
    }

    void Die()
    {
        Instantiate(deathEffect,transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
    }
}
