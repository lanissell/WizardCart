using System;
using UnityEngine;

public class Enemy: MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Transform attackPoint;

    [SerializeField]
    private AttackSystemData attackSystemData;

    [SerializeField]
    private EnemyAnimationController enemyAnimationController;

    protected EnemyAnimationController EnemyAnimationController => enemyAnimationController;

    private BaseAttackSystem attackSystem;

    public virtual void Initialize()
    {
        attackSystem = new ExplosionAttackSystem(transform, target,
            enemyAnimationController, attackSystemData, attackPoint);
    }

    private void Awake()
    {
        Initialize();

        attackSystem.Enable();
    }

    private void Update()
    {
        attackSystem.Update();

        Vector3 targetPosition = target.position;
        Vector3 targetXZPosition = new Vector3(targetPosition.x, 0, targetPosition.z);

        transform.LookAt(targetXZPosition);
    }
}