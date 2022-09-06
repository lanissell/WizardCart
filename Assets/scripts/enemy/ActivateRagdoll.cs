using System;
using UnityEngine;

namespace enemy
{
    public class ActivateRagdoll : MonoBehaviour
    {
        public Action childCollision;
        public event Action OnRagdollActive;
        private Animator _animator;
        [SerializeField]
        private Rigidbody[] rigidbodies;
        [SerializeField] 
        private EnemyCollisionWithWeapon[] enemyCollisions;
        

        private void Awake()
        {
            foreach (var rb in rigidbodies) rb.isKinematic = true;
            foreach (var c in enemyCollisions) c.activateRagdoll = this;
        }

        private void Start()
        {
            _animator = GetComponent<Animator>();
            childCollision += ActivateRagdollMethod;
        }

        private void ActivateRagdollMethod()
        {
            _animator.enabled = false;
            OnRagdollActive?.Invoke();
            foreach (var rb in rigidbodies) rb.isKinematic = false;
            foreach (var c in enemyCollisions) Destroy(c);
        }

    }
}
