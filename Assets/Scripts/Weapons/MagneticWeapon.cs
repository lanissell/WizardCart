using System;
using System.Collections;
using Enemy;
using UnityEngine;

namespace Weapons
{
    [RequireComponent(typeof(Rigidbody))]
    public class MagneticWeapon : MonoBehaviour
    {
        [SerializeField]
        private float _magneticSpeed;
        [SerializeField]
        private float _rotationSpeed;
        private Rigidbody _rb;
        private Transform _transform;
        private Transform _target;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _transform = transform;
            _rb.AddTorque(_transform.up * 1000);
        }

        private void Update()
        {
            if (_target == null) return;
            if (_rb.velocity.magnitude < 2f) return;
            RotateToTarget(_target);
            _rb.AddForce(_transform.forward * (Time.deltaTime * _magneticSpeed * 1000));


        }

        private void RotateToTarget(Transform target)
        {
            var direction = target.position - _transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            _transform.rotation = Quaternion.Lerp(_transform.rotation, rotation, Time.deltaTime * _rotationSpeed);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out WeaponMagneticArea _)) return;
            _target = other.transform;
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent(out WeaponMagneticArea _)) return;
            _target = null;
        }
        
    }
}
