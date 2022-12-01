using System;
using Enemy;
using Projectile_and_particle;
using UnityEngine;
using Weapons;

namespace enemy
{
    [RequireComponent(typeof(Rigidbody))]
    public class EnemyLimb : MonoBehaviour, IWeaponVisitor
    {
        [HideInInspector]
        public Transform Parent;
        [HideInInspector]
        public Rigidbody Rigidbody;

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
        }

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
            GlobalEventManager.SendOnEnemyDie(Parent);
        }
        
    }
}
