using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class InputManager : MonoBehaviour
{
    public static InputManager Instance => _instance;
    private static InputManager _instance;

    private TouchControls _touchControls;

    public delegate void StartTouchEvent(Vector2 position);
    public event StartTouchEvent OnStartTouch;

    public delegate void EndTouchEvent(Vector2 position);
    public event StartTouchEvent OnEndTouch;

    private void Awake()
    {
        _touchControls = new TouchControls();
        _instance = this;
    }

    private void OnEnable() => _touchControls.Enable();

    private void OnDisable() => _touchControls.Disable();

    private void Start()
    {
        _touchControls.Touch.TouchPress.started += ctx => StartTouch(ctx);
        _touchControls.Touch.TouchPress.canceled += ctx => EndTouch(ctx);
    }

    private void StartTouch(InputAction.CallbackContext ctx)
    {
        OnStartTouch?.Invoke(_touchControls.Touch.TouchPosition.ReadValue<Vector2>());
    }

    private void EndTouch(InputAction.CallbackContext ctx)
    {
        OnEndTouch?.Invoke(_touchControls.Touch.TouchPosition.ReadValue<Vector2>());
    }
}
