using UnityEngine;
using UnityEngine.InputSystem;
public class Player_Active_Input : MonoBehaviour
{
    public LayerMask GroundLayers;
    public float MaxSpeed = 5f;
    public float Acceleration = 30f;
    public float Deceleration = 30f;
    public float TurnSpeed = 40f;
    public float JumpForce = 5f;

    private Rigidbody2D _rb;
    private bool _isGrounded;

   
    // Input
    private InputAction _moveAction;
    private InputAction _jumpAction;
    private int _inputMoveX;

    public int InputMoveX => _inputMoveX;
    public bool IsGrounded => _isGrounded;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
        _jumpAction = InputSystem.actions.FindAction("Jump");
        Debug.Log($"Move found: {_moveAction != null} | Jump found: {_jumpAction != null} | Jump enabled: {_jumpAction?.enabled}");
    }

    // Update is called once per frame
    private void Update()
    {
        CheckGround();
        GatherInput();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void CheckGround()
    {
        bool grounded = Physics2D.OverlapBox(transform.position, new Vector2(.7f, 1f), 0, GroundLayers);
        _isGrounded = grounded;
    }

    private void GatherInput()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        Debug.Log("RAW space detected");

        Vector2 moveInput = _moveAction.ReadValue<Vector2>();
        _inputMoveX = Mathf.RoundToInt(moveInput.x);

       if (_jumpAction.WasPressedThisFrame())
        {
    Debug.Log($"Jump pressed → Grounded = {_isGrounded}");
    if (_isGrounded) Jump();
        }
    }

    private void Movement()
    {
        float targetVelocityX = _inputMoveX * MaxSpeed;
        float currSpeed;

        if (_inputMoveX != 0)
        {
            if (Mathf.Sign(targetVelocityX) != Mathf.Sign(_rb.linearVelocityX))
            {
                // Jika sedang berbalik arah, pake TurnSpeed
                currSpeed = TurnSpeed;
            }
            else
            {
                // Jika sedang mempercepat, pake Acceleration speed
                currSpeed = Acceleration;
            }
        }
        else
        {
            // Jika tidak ada input, gunakan kecepatan deselerasi
            currSpeed = Deceleration;
        }

        float smoothedVelocityX = Mathf.MoveTowards(_rb.linearVelocityX, targetVelocityX, currSpeed * Time.fixedDeltaTime);
        _rb.linearVelocityX = smoothedVelocityX;
    }

    private void Jump()
    {
        _rb.linearVelocity= new Vector2(_rb.linearVelocityX, JumpForce);
        
    }

   

}
