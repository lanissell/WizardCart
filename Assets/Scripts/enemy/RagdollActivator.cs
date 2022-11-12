using System;
using UnityEngine;

namespace enemy
{
    public class RagdollActivator : MonoBehaviour
    {
        public event Action OnRagdollActive;
        private Animator _animator;
        [SerializeField]
        private Rigidbody[] _rigidbodies;
        [SerializeField]
        private EnemyLimb[] _enemyLimbs;
        

        private void Awake()
        {
            foreach (Rigidbody rb in _rigidbodies) rb.isKinematic = true;
            foreach (EnemyLimb c in _enemyLimbs) c.OnLimbHit += ActivateRagdoll;
        }

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void ActivateRagdoll()
        {
            _animator.enabled = false;
            OnRagdollActive?.Invoke();
            foreach (EnemyLimb limb in _enemyLimbs)
            {
                limb.OnLimbHit -= ActivateRagdoll;
                Destroy(limb);
            }
            foreach (Rigidbody rb in _rigidbodies) rb.isKinematic = false;

        }

    }
}
