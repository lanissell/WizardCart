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
        private Rigidbody[] _rigidbodies;
        [SerializeField] 
        private EnemyLimbCollision[] _enemyCollisions;
        

        private void Awake()
        {
            foreach (Rigidbody rb in _rigidbodies) rb.isKinematic = true;
            foreach (EnemyLimbCollision c in _enemyCollisions) c.ActivateRagdoll = this;
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
            foreach (Rigidbody rb in _rigidbodies) rb.isKinematic = false;
            foreach (EnemyLimbCollision c in _enemyCollisions) Destroy(c);
        }

    }
}
