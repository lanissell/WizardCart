using UnityEngine;

public abstract class BaseAttackSystem
{
    private AttackSystemData attackSystemData;

    protected AttackSystemData AttackSystemData => attackSystemData;

    private EnemyAnimationController animationController;

    private Transform target;

    private Transform myTransform;

    private bool isActive;

    private bool attackEnded;

    protected bool AttackEnded
    {
        get => attackEnded;
        set => attackEnded = value;
    }

    protected BaseAttackSystem(Transform myTransform, Transform target,
        EnemyAnimationController animationController, AttackSystemData attackSystemData)
    {
        this.myTransform = myTransform;
        this.target = target;
        this.animationController = animationController;
        this.attackSystemData = attackSystemData;

        isActive = false;
        AttackEnded = false;
    }
    
    public void Enable()
    {
        animationController.AttackAnimationEnded += Attack;

        isActive = true;
        AttackEnded = true;
    }

    public void Update()
    {
        float distance = Vector3.Distance(target.position, myTransform.position);

        if (distance > attackSystemData.AttackDistance)
        {
            return;
        }

        if (isActive && AttackEnded)
        {
            animationController.PlayAttackAnimation();
            attackEnded = false;
        }
    }

    public virtual void Disable()
    {
        animationController.AttackAnimationEnded -= Attack;
    }

    protected abstract void Attack();
}