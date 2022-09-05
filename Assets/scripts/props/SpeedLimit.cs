using System;
using UnityEngine;

namespace props
{
    [RequireComponent(typeof(Rigidbody))]
    public class SpeedLimit : MonoBehaviour
    {
        private Rigidbody _rb;
        [SerializeField] private float maxSpeed;
        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (_rb.velocity.magnitude > maxSpeed) _rb.velocity = _rb.velocity.normalized * maxSpeed;
        }
    }
}
