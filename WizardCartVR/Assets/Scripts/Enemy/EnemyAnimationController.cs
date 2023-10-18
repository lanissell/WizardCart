using System;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    public event Action AttackAnimationEnded;

    [SerializeField]
    private Animator animator;

    private static readonly int Attack = Animator.StringToHash("Attack");

    public void Initialize()
    {
        SetEnabled(true);
    }

    public void PlayAttackAnimation()
    {
        animator.SetTrigger(Attack);
    }

    public void SetEnabled(bool enabled)
    {
        animator.enabled = enabled;
    }

    public void EndAttackAnimation()
    {
        AttackAnimationEnded?.Invoke();
    }
}