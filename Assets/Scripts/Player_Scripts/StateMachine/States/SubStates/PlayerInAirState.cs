using UnityEngine;

public class PlayerInAirState : PlayerState
{
    private bool isGrounded;
    private Vector2 walkInput;
    private bool jumpInput;
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
        CheckCoyoteTIme();
        base.LogicUpdate();
        walkInput = player.playerInputHandler.MovementInput;
        jumpInput = player.playerInputHandler.JumpInput;

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
    private void CheckCoyoteTIme()
    {
        if (coyoteTime && Time.time > stateTime + data.coyoteTime)
        {
            coyoteTime = false;
            player.playerJumpState.NoOfJumpsDecrease();
        }
    }
    public void StartCoyoteTime() => coyoteTime = true;
}
