using UnityEngine;

public class PlayerSprintState : PlayerGroundedState
{
    public PlayerSprintState(Player player, PlayerStateMachine playerStateMachine, Data data, string _animBoolName) : base(player, playerStateMachine, data, _animBoolName)
    {

    }
    public override void Enter()
    {
        base.Enter();
    }
    public override void Exit()
    {
        base.Exit();
        player.SetSprintingVelocity(data.walkingVelocity);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        player.Flip();
        if (!sprintInput)
        {
            playerStateMachine.ChangeState(player.playerMoveState);
        }
        if (walkInput.x == 0)
        {
            playerStateMachine.ChangeState(player.playerIdelState);
        }
    }
    public override void PhysicsUpdate()
    {
        player.SetSprintingVelocity(data.sprintingVelocity * walkInput.x);
        base.PhysicsUpdate();
    }
    public override void DoCheck()
    {
        base.DoCheck();
    }
}
