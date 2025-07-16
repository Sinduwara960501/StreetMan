using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player player, PlayerStateMachine playerStateMachine, Data data, string _animBoolName) : base(player, playerStateMachine, data, _animBoolName)
    {

    }
    public override void Enter()
    {
        base.Enter();
    }
    public override void Exit()
    {
        base.Exit();
        player.SetWalkingVelocity(0f);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        player.Flip();
        if (walkInput.x == 0)
        {
            playerStateMachine.ChangeState(player.playerIdelState);
        }
        if (sprintInput)
        {
            playerStateMachine.ChangeState(player.playerSprintState);
        }

    }
    public override void PhysicsUpdate()
    {
        player.SetWalkingVelocity(data.walkingVelocity * walkInput.x);
        base.PhysicsUpdate();
    }
    public override void DoCheck()
    {
        base.DoCheck();
    }
}
