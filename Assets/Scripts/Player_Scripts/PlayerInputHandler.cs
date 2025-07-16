using System;
using UnityEngine;
using UnityEngine.InputSystem;

public enum CombatInputs
{
    primary,
    secondary
}
public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 MovementInput { get; private set; }
    public bool SprintInput { get; private set; }
    public bool JumpInput { get; private set; }
    public bool[] AttackInputs { get; private set; }
    [SerializeField]
    private float InputHoldTime = 0.2f;
    private float JumpInputStartTime;
    public float SprintInputStartTime;

    private void Start()
    {
        int Count = Enum.GetValues(typeof(CombatInputs)).Length;
        AttackInputs = new bool[Count];
    }
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
            SprintInputStartTime = Time.time;
        }
        else if (context.canceled)
        {
            SprintInput = false;
        }
    }

    public void OnPrimaryAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AttackInputs[(int)CombatInputs.primary] = true;
        }
        if (context.canceled)
        {
            AttackInputs[(int)CombatInputs.primary] = false;
        }
    }

    public void OnSecondaryAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AttackInputs[(int)CombatInputs.secondary] = true;
        }
        if (context.canceled)
        {
            AttackInputs[(int)CombatInputs.secondary] = false;
        }
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            JumpInput = true;
            JumpInputStartTime = Time.time;
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

