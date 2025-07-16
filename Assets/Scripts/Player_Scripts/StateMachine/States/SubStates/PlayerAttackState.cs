using UnityEngine;

public class PlayerAttackState : PlayerAbilityState
{
    private AttackManager attackManager;
    public PlayerAttackState(Player player, PlayerStateMachine playerStateMachine, Data data, string _animBoolName) : base(player, playerStateMachine, data, _animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();
        attackManager.EnterAttack();
    }

    public override void Exit()
    {
        base.Exit();
        attackManager.ExitAttack();
    }

    public void SetAttack(AttackManager attackManager)
    {
        this.attackManager = attackManager;
        attackManager.InitializeAttack(this);
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
        isAbilityDone = true;
    }
}
