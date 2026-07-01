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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

            if (damageable != null)
            {
                Debug.Log("Daño al Player");

                damageable.TakeDamage(1);
            }
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    
}
