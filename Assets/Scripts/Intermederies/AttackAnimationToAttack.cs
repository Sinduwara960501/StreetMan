using UnityEngine;

public class AttackAnimationToAttack : MonoBehaviour
{
    private AttackManager attackManager;

    private void Start()
    {
        attackManager = GetComponentInParent<AttackManager>();
    }

    private void AnimationFinishTrigger()
    {
        attackManager.AnimationFinishTrigger();
    }
}
