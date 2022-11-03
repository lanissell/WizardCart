using System;
using Enemy;
using Projectile_and_particle;
using UnityEngine;
using Weapons;

namespace enemy
{
    [RequireComponent(typeof(StickyObject))]
    public class EnemyLimb : MonoBehaviour, IWeaponVisitor
    {
        public event Action OnLimbHit; 

        public void Visit(Sharp sharp)
        {
            DefaultReaction();
        }
        
        public virtual void Visit(FireBall fireBall)
        {
            DefaultReaction();
        }
        
        private void DefaultReaction()
        {
            OnLimbHit?.Invoke();
        }
    }
}
