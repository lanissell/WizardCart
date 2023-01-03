using System.Security.Cryptography;
using UnityEngine;

namespace enemy
{
    public class RagdollActivator : MonoBehaviour
    {
        [SerializeField]
        private EnemyLimb[] _enemyLimbs;
        private Animator _animator;
        private Transform _transform;
        
        private void Start()
        {
            EnemyLimb.OnLimbCollideWithWeapon += ActivateRagdoll;
            _transform = transform;
            _animator = GetComponent<Animator>();
            foreach (EnemyLimb limb in _enemyLimbs)
            {
                limb.Parent = _transform;
                limb.Rigidbody.isKinematic = true;
            }
        }

        private void ActivateRagdoll(Transform diedTransform)
        {
            if(_transform != diedTransform) return;
            _animator.enabled = false;
            foreach (EnemyLimb limb in _enemyLimbs)
            {
                limb.Rigidbody.isKinematic = false;
                Destroy(limb);
            }
            Destroy(this);
            EnemyLimb.OnLimbCollideWithWeapon -= ActivateRagdoll;
        }

    }
}
