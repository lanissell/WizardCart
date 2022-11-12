using chunk;
using enemy;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(RagdollActivator))]
    public class Wizard : MonoBehaviour
    {
        [SerializeField]
        private float _destroyAfterDieTime;

        private Vector3 _targetPosition;
        private RagdollActivator _ragdollActivator;

        private void Start()
        {
            _ragdollActivator = GetComponent<RagdollActivator>();
            _targetPosition = Camera.main.transform.position;
            _ragdollActivator.OnRagdollActive += Die;
        }

        private void Update()
        {
            transform.LookAt(new Vector3(_targetPosition.x, 0, _targetPosition.z));
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
            Destroy(_ragdollActivator);
        }
    }
}