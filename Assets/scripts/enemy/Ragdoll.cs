using System;
using UnityEngine;

namespace enemy
{
    public class Ragdoll : MonoBehaviour
    {
        public event Action OnChildCollision;
        public event Action OnRagdollActive;
        private Animator _animator;
        [SerializeField]
        private Rigidbody[] rigidbodies;
        [SerializeField] 
        private EnemyLimbCollision[] enemyCollisions;
        

        private void Awake()
        {
            foreach (var rb in rigidbodies) rb.isKinematic = true;
            foreach (var c in enemyCollisions) c.activateRagdoll = this;
        }

        private void Start()
        {
            _animator = GetComponent<Animator>();
            OnChildCollision += ActivateRagdoll;
        }

        public void SendOnChildCollision() => OnChildCollision?.Invoke();

        private void ActivateRagdoll()
        {
            _animator.enabled = false;
            OnRagdollActive?.Invoke();
            foreach (var rb in rigidbodies) rb.isKinematic = false;
            foreach (var c in enemyCollisions) Destroy(c);
        }

    }
}
