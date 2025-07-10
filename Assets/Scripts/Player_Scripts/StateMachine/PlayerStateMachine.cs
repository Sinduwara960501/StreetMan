using UnityEngine;

public class PlayerStateMachine
{
    public PlayerState playerState { get; private set; }

    public void Initialize(PlayerState startingState)
    {
        playerState = startingState;
        playerState.Enter();
    }
    public void ChangeState(PlayerState newState)
    {
        playerState.Exit();
        playerState = newState;
        playerState.Enter();
    }
}
