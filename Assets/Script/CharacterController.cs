using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;




public class CharacterController : BaseEntity, IDamageable
{
    public InputSystem_Actions inputs;
 
    public Rigidbody2D rigibody;

    [Header("Estadísticas de Movimiento")]
    public float Speed = 8f;
    public float JumpForce = 15f;

    [Header("Estadísticas de Dash")]
    public float DashSpeed = 20f;
    public float StepBackSpeed = 15f;
    public float DashDuration = 0.2f;

    [Header("Estados")]
    public bool IsGrounded;
    public float MoveInput;

    private int facingDirection = 1; // 1 = Derecha, -1 = Izquierda
    private bool isDashing = false;

    private void Awake()
    {
        inputs = new();
    }
    private void OnEnable()
    {
        inputs.Enable();
        inputs.Player.Movement.performed += OnMovementStart;
        inputs.Player.Movement.canceled += OnMovementFinish;

        inputs.Player.Jump.performed += OnJumpStart;
        //inputs.Player.Dash.performed += OnDashStart;
        //inputs.Player.StepBack.performed += OnStepBack;
    }
    private void OnDisable()
    {
        // Siempre es buena práctica limpiar los eventos al deshabilitar
        inputs.Disable();
        inputs.Player.Movement.performed -= OnMovementStart;
        inputs.Player.Movement.canceled -= OnMovementFinish;
        inputs.Player.Jump.performed -= OnJumpStart;
        //inputs.Player.Dash.performed -= OnDashStart;
        //inputs.Player.StepBack.performed -= OnStepBack;
    }

    void Start()
    {

    }
    private void Update()
    {
        // Si estamos dasheando, no permitimos que el movimiento normal interfiera
        if (isDashing) return;

        // Aplicamos el movimiento. 
        rigibody.linearVelocity = new Vector2(MoveInput * Speed, rigibody.linearVelocity.y);

    }
    private void OnMovementStart(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>().x;

        if (MoveInput > 0) facingDirection = 1;
        else if (MoveInput < 0) facingDirection = -1;
    }
    private void OnMovementFinish(InputAction.CallbackContext context)
    {
        MoveInput = 0;
    }
    private void OnJumpStart(InputAction.CallbackContext context)
    {
        if (IsGrounded && !isDashing)
        {
            // Reseteamos la velocidad en Y antes de saltar para que el salto siempre tenga la misma fuerza
            rigibody.linearVelocity = new Vector2(rigibody.linearVelocity.x, 0);
            rigibody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
    }

    public void TakeDamage()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            rigibody.linearDamping = 15;
            IsGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            rigibody.linearDamping = 1;
            IsGrounded = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ICollectable>() != null)
        {
            collision.gameObject.GetComponent<ICollectable>().Collect();
        }

    }
}