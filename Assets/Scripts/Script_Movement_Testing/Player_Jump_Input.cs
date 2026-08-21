using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Jump_Input : MonoBehaviour
{
    public event Action OnJump;
    public LayerMask GroundLayers;
    public float JumpForce = 5f;
    private Rigidbody2D _rb;
    private InputAction _jumpAction;
    private bool _isGrounded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        InputSystem.actions.FindActionMap("Player").Enable();
        _jumpAction = InputSystem.actions.FindAction("Jump");
    }
    private  void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
         CheckGround();
         GatherInput();
    }

    private void CheckGround()
    {
        bool grounded = Physics2D.OverlapBox(transform.position, new Vector2(.7f, 1f), 0, GroundLayers);
        _isGrounded = grounded;
    }

    private void GatherInput()
    {
       if (_jumpAction.WasPressedThisFrame())
        {
    Debug.Log($"Jump pressed → Grounded = {_isGrounded}");
    if (_isGrounded) Jump();
        }
    }
    private void Jump()
    {
        _rb.linearVelocity= new Vector2(_rb.linearVelocityX, JumpForce);
        OnJump?.Invoke();
    }
}
