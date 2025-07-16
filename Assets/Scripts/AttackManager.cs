using UnityEngine;

public class AttackManager : MonoBehaviour
{
    protected Animator _attackAnimator;
    protected PlayerAttackState playerAttackState;

    protected virtual void Awake()
    {
        _attackAnimator = transform.Find("Attack").GetComponent<Animator>();
        gameObject.SetActive(false);
    }

    public virtual void EnterAttack()
    {
        gameObject.SetActive(true);
        _attackAnimator.SetBool("attack", true);
    }
    public virtual void ExitAttack()
    {
        gameObject.SetActive(false);
        _attackAnimator.SetBool("attack", false);
    }

    public virtual void AnimationFinishTrigger()
    {
        playerAttackState.AnimationFinishTrigger();
    }

    public void InitializeAttack(PlayerAttackState attackState)
    {
        playerAttackState = attackState;
    }
}
