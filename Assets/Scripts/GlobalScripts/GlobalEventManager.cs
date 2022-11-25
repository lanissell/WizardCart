using System;
using enemy;
using Projectile_and_particle;
using UnityEngine;

public static class GlobalEventManager
{
        public static event Action OnEnemyHit;
        public static event Action<Projectile> OnProjectileAttackerDestroy;
        public static event Action<Transform> OnEnemyDie;
        public static event Action OnRunStart;
        
        public static void SendOnEnemyHit() => OnEnemyHit?.Invoke();
        
        public static void SendOnProjectileAttackerDestroy(Projectile projectile) => OnProjectileAttackerDestroy?.Invoke(projectile);

        public static void SendOnEnemyDie(Transform transform) => OnEnemyDie?.Invoke(transform);

        public static void SendOnRunStart() => OnRunStart?.Invoke();

}