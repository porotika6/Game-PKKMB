using UnityEngine;
using UnityEngine.InputSystem;
public class ClicktoStart : MonoBehaviour
{
    private bool _started = false;
    private InputAction _startAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0;
        _startAction = InputSystem.actions.FindAction("jump");
    }

    // Update is called once per frame
    void Update()
    {
        if (!_started && _startAction.WasPressedThisFrame())
        {
            _started = true;
            Time.timeScale = 1;
        }
    }
}
