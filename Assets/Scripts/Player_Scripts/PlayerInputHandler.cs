using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 MovementInput { get; private set; }
    public bool SprintInput { get; private set; }
    public bool JumpInput { get; private set; }
    [SerializeField]
    private float InputHoldTime = 0.2f;
    private float JumpInputStartTime;
    private void Update()
    {
        CheckJumpInputHoldTime();
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        MovementInput = context.ReadValue<Vector2>();
    }
    public void OnSprintInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SprintInput = true;
            JumpInputStartTime = Time.time;
        }
        else if (context.canceled)
        {
            SprintInput = false;
        }
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            JumpInput = true;
        }
    }
    public void UseJumpInput() => JumpInput = false;
    private void CheckJumpInputHoldTime()
    {
        if (Time.time >= JumpInputStartTime + InputHoldTime)
        {
            JumpInput = false;
        }
    }
}

