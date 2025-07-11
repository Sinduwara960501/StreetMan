using UnityEngine;

public class PlayerLandState : PlayerGroundedState
{
    public PlayerLandState(Player player, PlayerStateMachine playerStateMachine, Data data, string _animBoolName) : base(player, playerStateMachine, data, _animBoolName)
    {

    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (walkInput.x != 0)
        {
            playerStateMachine.ChangeState(player.playerMoveState);

            if (jumpInput)
            {
                playerStateMachine.ChangeState(player.playerSprintState);
            }
        }
    }
}
