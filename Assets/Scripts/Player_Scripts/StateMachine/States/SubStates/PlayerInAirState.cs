using UnityEngine;

public class PlayerInAirState : PlayerState
{
    private bool isGrounded;
    private Vector2 walkInput;
    private bool jumpInput;
    private bool sprintInput;
    private bool coyoteTime;

    public PlayerInAirState(Player player, PlayerStateMachine playerStateMachine, Data data, string _animBoolName) : base(player, playerStateMachine, data, _animBoolName)
    {

    }
    public override void Enter()
    {
        base.Enter();
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        CheckCoyoteTime();
        walkInput = player.playerInputHandler.MovementInput;
        jumpInput = player.playerInputHandler.JumpInput;
        sprintInput = player.playerInputHandler.SprintInput;

        if (isGrounded && player.CurruntVelocity.y < 0.01f)
        {
            playerStateMachine.ChangeState(player.playerLandState);

        }
        else if (jumpInput && player.playerJumpState.CanJump())
        {
            playerStateMachine.ChangeState(player.playerJumpState);
        }

        else
        {
            player.Flip();
            player.SetWalkingVelocity(data.walkingVelocity * walkInput.x);
            player.Anim.SetFloat("velocityY", player.CurruntVelocity.y);

            if (CheckSprintBeforeJump())
            {
                player.SetSprintingVelocity(data.sprintingVelocity * walkInput.x);
            }
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
    private void CheckCoyoteTime()
    {
        if (coyoteTime && Time.time > stateTime + data.coyoteTime)
        {
            coyoteTime = false;
            player.playerJumpState.NoOfJumpsDecrease();
        }
    }

    private bool CheckSprintBeforeJump() 
    {
        return sprintInput && player.playerInputHandler.SprintInputStartTime < stateTime;
    }
    
    public void StartCoyoteTime() => coyoteTime = true;
}
