using System;
using UnityEngine;

public class Enemy : BaseEntity, IDamageable
{

    [SerializeField] private int health = 1;

    public void TakeDamage(int damage)
    {

        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger con " + other.name + other.gameObject.tag);
         
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("trigger");

            IDamageable damageable = other.gameObject.GetComponent<IDamageable>();

            if (damageable != null)
            {
                Debug.Log("Daño al Player");

                damageable.TakeDamage(1);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    
}
