using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{
    public PlayerJumpState(Player player, PlayerStateMachine playerStateMachine, Data data, string _animBoolName) : base(player, playerStateMachine, data, _animBoolName)
    {

    }
    public override void Enter()
    {
        base.Enter();
        player.SetJumpVelocity(data.jumpVelocity);
        isAbilityDone = true;
    }
}
