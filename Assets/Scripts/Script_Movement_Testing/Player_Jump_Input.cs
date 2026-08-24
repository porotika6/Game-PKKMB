using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Jump_Input : MonoBehaviour
{
    public event Action OnJump;
    public LayerMask GroundLayers;
    public float JumpForce = 5f;
    private Rigidbody2D _rb;
    private BoxCollider2D _boxCollider;
    private InputAction _jumpAction;
    private bool _isGrounded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
        InputSystem.actions.FindActionMap("Player").Enable();
        _jumpAction = InputSystem.actions.FindAction("Jump");
    }
    // Update is called once per frame
    private void Update()
    {
         CheckGround();
         GatherInput();
    }
    private void CheckGround()
    {
        bool grounded = Physics2D.OverlapBox(_boxCollider.bounds.center, _boxCollider.bounds.size, 0, GroundLayers);
        _isGrounded = grounded;
    }
    // private void OnDrawGizmos()
    // {
    //     if(_boxCollider == null) _boxCollider.GetComponent<BoxCollider2D>();
    //     Gizmos.color = _isGrounded ? Color.green : Color.red;
    //     Gizmos.DrawWireCube(_boxCollider.bounds.center, _boxCollider.bounds.size);
    // }
    private void GatherInput()
    {
        if (_jumpAction.WasPressedThisFrame() && Time.timeScale != 0f)
        {
            // 1. Cek apakah sentuhan/klik mengenai UI Button
            if (IsPointerOverUI())
            {
                // Jika ya, abaikan lompatan karena user sedang menekan UI
                return;
            }

            Debug.Log($"Jump pressed → Grounded = {_isGrounded}");
            if (_isGrounded) Jump();
        }
    }
    private void Jump()
    {
        _rb.linearVelocity= new Vector2(_rb.linearVelocityX, JumpForce);
        OnJump?.Invoke();
    }
    private bool IsPointerOverUI()
    {
        if (UnityEngine.EventSystems.EventSystem.current == null) return false;

        // Ambil posisi pointer saat ini berdasarkan perangkat yang aktif
        Vector2 pointerPosition = Vector2.zero;
        if (Pointer.current != null)
        {
            pointerPosition = Pointer.current.position.ReadValue();
        }
        else if (Touchscreen.current != null && Touchscreen.current.touches.Count > 0)
        {
            pointerPosition = Touchscreen.current.touches[0].position.ReadValue();
        }
        else
        {
            return false;
        }

        // Tembakkan Raycast khusus UI pada posisi pointer tersebut
        var eventData = new UnityEngine.EventSystems.PointerEventData(UnityEngine.EventSystems.EventSystem.current);
        eventData.position = pointerPosition;

        System.Collections.Generic.List<UnityEngine.EventSystems.RaycastResult> results = new();
        UnityEngine.EventSystems.EventSystem.current.RaycastAll(eventData, results);

        // Kembalikan nilai true hanya jika raycast menyentuh objek UI
        return results.Count > 0;
    }
}