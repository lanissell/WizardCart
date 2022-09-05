using UnityEngine;

namespace enemy
{
    public class ActivateRagdoll : MonoBehaviour
    {
        private Animator _animator;
        [SerializeField]
        private Rigidbody[] rigidbodies;

        private void Awake()
        {
            foreach (var rb in rigidbodies) rb.isKinematic = true;
        }

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void ActivateRagdollMethod()
        {
            _animator.enabled = false;
            foreach (var rb in rigidbodies) rb.isKinematic = false;
        }

    }
}
