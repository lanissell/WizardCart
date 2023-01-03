using System;
using UnityEngine;

namespace Enemies
{
    public abstract class Enemy: MonoBehaviour
    {
        public static event Action<Transform> OnEnemyDied;

        protected virtual void Die(Transform diedTransform)
        {
            OnEnemyDied?.Invoke(diedTransform);
        }
    }
}