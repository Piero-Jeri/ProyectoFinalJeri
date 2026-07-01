using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public enum PlayerController
{
    None,
    Player1,
    Player2
}

public class Player : BaseEntity
{
    public AudioManager audioManager;

    public InputSystem_Actions inputs;

    public PlayerController playerController;

    public Animator animator;

    //[SerializeField] private Transform controladorDisparo;
    //[SerializeField] private float rango;

    [SerializeField] private Transform firePoint;
    [SerializeField] private float distance = 3f;
    [SerializeField] private LayerMask enemyLayer;



    public Vector2 MoveInput;
    public float MoveSpeed;

   //public CircleCollider2D coll;
    public float range;

    public List<GameObject> Enemys = new();

    private void Awake()
    {
      //  coll = GetComponent<CircleCollider2D>();
      //  coll.radius = range;

        inputs = new();
    }

    private void OnEnable()
    {
        inputs.Enable();
     

        switch (playerController)
        {

            case PlayerController.None:
                break;

            case PlayerController.Player1:
                {
                    inputs.Player1.Move.performed += OnPlayerMove;
                    inputs.Player1.Move.canceled += OnPlayerMoveCanceled;

                    inputs.Player1.Attack1.performed += OnAttack1;
                    inputs.Player1.Attack2.performed += OnAttack2;
                }
                break;

            case PlayerController.Player2:
                {
                    inputs.Player2.Move.performed += OnPlayerMove;
                    inputs.Player2.Move.canceled += OnPlayerMoveCanceled;

                    inputs.Player2.Attack1.performed += OnAttack1;
                    inputs.Player2.Attack2.performed += OnAttack2;
                }
                break;
      
        }
        

    }


    void Start()
    {
        //InvokeRepeating("AutoAttackEnemies", 1f, 1f);
    }

    void Update()
    {
        OnMove();

   
    }

    private void OnAttack2(InputAction.CallbackContext context)
    {
        Debug.Log("A2");

    }

    private void OnAttack1(InputAction.CallbackContext context)
    {
        Debug.Log("A1");

        animator.SetTrigger("OnShooting");

        audioManager.playDisparar();

        if (context.performed)
        {
            Debug.Log("atacado!");

            Shoot();
        }
    }

    private void OnPlayerMoveCanceled(InputAction.CallbackContext context)
    {
        MoveInput = Vector2.zero;
        animator.SetBool("OnWalking", false);
    }

    private void OnPlayerMove(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
        animator.SetBool("OnWalking", true);
        audioManager.playCaminar();
    }


    public void OnMove()
    {
        if(MoveInput != Vector2.zero)
        {
            transform.position += (Vector3)MoveInput * MoveSpeed * Time.deltaTime;

            //transform.Translate(MoveInput * 5f * Time.deltaTime);

            if (MoveInput.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (MoveInput.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }

        }

    }

    public void Shoot()
    {
        /*RaycastHit2D raycastHit2D = Physics2D.Raycast(controladorDisparo.position, controladorDisparo.right, rango);
        Debug.DrawRay(transform.position, Vector2.right * 1.5f, Color.red);

        if (raycastHit2D)
        {
            if (raycastHit2D.transform.CompareTag("Enemy"))
            {
                Destroy(gameObject);
            }
        }*/
        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, firePoint.right, distance, enemyLayer);


        if (hit.collider != null)
        {
            IDamageable damageable = hit.collider.GetComponent<IDamageable>();
            Debug.Log("Golpeó: " + hit.collider.name);

            if (damageable != null)
            {
                damageable.TakeDamage(1);
            }
            
        }
        else
            {
                Debug.Log("No golpeó nada");
            }

    }
    private void OnDrawGizmos()
    {
        if (firePoint == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(
            firePoint.position,
            firePoint.position + firePoint.right * distance);
    }

    [SerializeField] private int health = 1;

    public void TakeDamage(int damage)
    {
        health -= damage;

        Debug.Log("Daño al Player");

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("El jugador murió");
        Destroy(gameObject);
    }

    /*public void AutoAttackEnemies()
    {
        print("ATAQUE!");

        foreach (GameObject enemy in Enemys)
        {
            float distance = Vector3.Distance(enemy.transform.position, transform.position);
            if (distance <= range && enemy.GetComponent<Enemy>() != null)
                enemy.GetComponent<Enemy>().TakeDamage(this);
        }

    }*/

    private void OnDestroy()
    {
        Debug.Log("oh no me cancelaron");
    }


    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() != null)
            Enemys.Add(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if(Enemys.Find(collision.gameObject))
        Enemys.Remove(collision.gameObject);
    }*/
    
    /*public override void TakeDamage(BaseEntity damager)
    {
        // base.TakeDamage(damager);

        Debug.Log(damager.Element);

        int damage = damager.Stats.Power;

        switch (damager.Element)
        {
            case Elements.None:
                //damage = damage;
                break;
            case Elements.Fire:
                damage *= 2;
                break;
            case Elements.Water:
                damage /= 2;
                break;
            case Elements.Earth:
                damage *= 3;
                break;
            case Elements.Air:
                damage = 0;
                break;
            default:
                break;
        }

        stats.TakeDamage(damage);
    }*/
}
    
