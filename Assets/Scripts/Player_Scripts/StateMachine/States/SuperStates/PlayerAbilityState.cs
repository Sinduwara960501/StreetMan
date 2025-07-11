using UnityEngine;

public class PlayerAbilityState : PlayerState
{
    protected bool isAbilityDone;
    private bool isGrounded;
    public PlayerAbilityState(Player player, PlayerStateMachine playerStateMachine, Data data, string _animBoolName) : base(player, playerStateMachine, data, _animBoolName)
    {

    }
    public override void Enter()
    {
        base.Enter();
        isAbilityDone = false;
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isAbilityDone)
        {
            if (isGrounded && player.CurruntVelocity.y < 0.01f)
            {
                playerStateMachine.ChangeState(player.playerIdelState);
            }
            else
            {
                playerStateMachine.ChangeState(player.playerInAirState);
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
}
