using enemy;
using Projectile_and_particle;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Rigidbody))]
    public class FireEnemyLimb: EnemyLimb
    {
        public override void Visit(FireBall fireBall)
        {
            Debug.Log("Ignore fire");
        }
    }
}
