using chunk;
using enemy;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(RagdollActivator), typeof(ProjectileAttacker))]
    public class Wizard : MonoBehaviour
    {
        [SerializeField]
        private float _vewDist;
        [SerializeField]
        private float _destroyAfterDieTime;
        
        private ProjectileAttacker _attacker;
        private Transform _target;
        private Transform _transform;
        private RagdollActivator _ragdollActivator;

        private void Start()
        {
            _ragdollActivator = GetComponent<RagdollActivator>();
            _attacker = GetComponent<ProjectileAttacker>();
            _target = Camera.main.transform;
            _transform = transform;
            _ragdollActivator.OnRagdollActive += Die;
        }

        private void Update()
        {
            var targetPosition = _target.position;
            float dist = Vector3.Distance(_transform.position, targetPosition);
            if (dist > _vewDist) return;
            Vector3 position = _target.position;
            transform.LookAt(new Vector3(position.x, 0, position.z));
            _attacker.Attack(targetPosition, dist);
        }

        private void Die()
        {
            _ragdollActivator.OnRagdollActive -= Die;
            DestroyUnusedScripts();
            Destroy(gameObject, _destroyAfterDieTime);
        }

        private void DestroyUnusedScripts()
        {
            Destroy(this);
            Destroy(_attacker);
            Destroy(_ragdollActivator);
        }
    }
}