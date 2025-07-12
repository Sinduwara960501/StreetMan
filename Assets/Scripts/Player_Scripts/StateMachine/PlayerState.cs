using UnityEngine;

public class PlayerState
{
    protected Player player;
    protected PlayerStateMachine playerStateMachine;
    protected Data data;
    protected float stateTime;
    protected bool isAnimationFinished;
    private string _animBoolName;

    public PlayerState(Player player, PlayerStateMachine playerStateMachine, Data data, string _animBoolName)
    {
        this.player = player;
        this.playerStateMachine = playerStateMachine;
        this.data = data;
        this._animBoolName = _animBoolName;
    }
    public virtual void Enter()
    {
        DoCheck();
        stateTime = Time.time;
        player.Anim.SetBool(_animBoolName, true);
        isAnimationFinished = false;
        Debug.Log(_animBoolName);
    }
    public virtual void Exit()
    {
        player.Anim.SetBool(_animBoolName, false);
    }
    public virtual void LogicUpdate()
    {

    }
    public virtual void PhysicsUpdate()
    {
        DoCheck();
    }
    public virtual void DoCheck()
    {

    }
    public virtual void AnimationTrigger() { }
    public virtual void AnimationFinishTrigger() => isAnimationFinished = true;


}
