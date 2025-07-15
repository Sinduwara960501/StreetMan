using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{
    private int noOfJumpLeft;
    public PlayerJumpState(Player player, PlayerStateMachine playerStateMachine, Data data, string _animBoolName) : base(player, playerStateMachine, data, _animBoolName)
    {
        noOfJumpLeft = data.amountOfJumps;
    }
    public override void Enter()
    {
        base.Enter();
        player.SetJumpVelocity(data.jumpVelocity);
        isAbilityDone = true;
        noOfJumpLeft--;
    }
    public bool CanJump()
    {
        if (noOfJumpLeft > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void ResetNoOfJumpLeft() => noOfJumpLeft = data.amountOfJumps;
    public void NoOfJumpsDecrease() => noOfJumpLeft--;
}
