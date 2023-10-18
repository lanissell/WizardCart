using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class ExplosionAttackSystem : BaseAttackSystem
{
    private Transform center;

    private List<Projectile> activeProjectiles;

    public ExplosionAttackSystem(Transform myTransform, Transform target,
        EnemyAnimationController animationController, AttackSystemData attackSystemData,
        Transform center) : base(myTransform, target, animationController, attackSystemData)
    {
        activeProjectiles = new List<Projectile>();

        this.center = center;
    }

    public override void Disable()
    {
        base.Disable();

        foreach (var projectile in activeProjectiles)
        {
            projectile.gameObject.SetActive(false);
        }
    }

    protected override void Attack()
    {
        for (int i = 0; i < AttackSystemData.CountPerShot; i++)
        {
            var projectile = Object.Instantiate(AttackSystemData.ProjectilePrefab,
                center.position, Quaternion.identity);

            activeProjectiles.Add(projectile);

            var projectileTransform = projectile.transform;
            projectileTransform.localRotation = Quaternion.LookRotation(Random.insideUnitSphere);

            projectile.Push(projectileTransform.forward, AttackSystemData.ProjectilePushForce);
        }

        AttackEnded = true;
    }
}