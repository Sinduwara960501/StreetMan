using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected Vector2 walkInput;
    protected bool sprintInput;
    protected bool jumpInput;
    private bool isGrounded;
    public PlayerGroundedState(Player player, PlayerStateMachine playerStateMachine, Data data, string _animBoolName) : base(player, playerStateMachine, data, _animBoolName)
    {

    }
    public override void Enter()
    {
        base.Enter();
        player.playerJumpState.ResetNoOfJumpLeft();
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        walkInput = player.playerInputHandler.MovementInput;
        sprintInput = player.playerInputHandler.SprintInput;
        jumpInput = player.playerInputHandler.JumpInput;

        if (jumpInput && player.playerJumpState.CanJump())
        {
            player.playerInputHandler.UseJumpInput();
            playerStateMachine.ChangeState(player.playerJumpState);
        }
        else if (!isGrounded)
        {
            player.playerInAirState.StartCoyoteTime();
            playerStateMachine.ChangeState(player.playerInAirState);
        }

    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    public override void DoCheck()
    {
        base.DoCheck();
        isGrounded = player.CheckIfGrounded();

    }
}
