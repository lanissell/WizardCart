using UnityEngine;

namespace props
{
    [RequireComponent(typeof(Rigidbody))]
    public class SpeedLimit : MonoBehaviour
    {
        [SerializeField]
        private float _maxSpeed;
        private Rigidbody _rb;
        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (_rb.velocity.magnitude > _maxSpeed) _rb.velocity = _rb.velocity.normalized * _maxSpeed;
        }
    }
}
