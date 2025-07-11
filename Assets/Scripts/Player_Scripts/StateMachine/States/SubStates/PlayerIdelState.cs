using UnityEngine;

public class PlayerIdelState : PlayerGroundedState
{
    public PlayerIdelState(Player player, PlayerStateMachine playerStateMachine, Data data, string _animBoolName) : base(player, playerStateMachine, data, _animBoolName)
    {

    }
    public override void Enter()
    {
        player.SetWalkingVelocity(0f);
        base.Enter();
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (walkInput.x != 0)
        {
            playerStateMachine.ChangeState(player.playerMoveState);
        }
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    public override void DoCheck()
    {
        base.DoCheck();
    }
}
