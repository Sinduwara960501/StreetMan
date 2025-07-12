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

            if (sprintInput)
            {
                playerStateMachine.ChangeState(player.playerSprintState);
            }


        }
        else if (isAnimationFinished)
        {
            playerStateMachine.ChangeState(player.playerIdelState);
        }
    }
}
