using System.Collections;
using Enemy;
using UnityEngine;
using Weapons;

namespace Projectile_and_particle
{
    [RequireComponent(typeof(Rigidbody),typeof(Collider))]
    public class FireBall : Projectile, IWeapon
    {
        private Collider _collider;
        [SerializeField]
        private float _timeToActiveCollisionBeforeThrow;
        [SerializeField]
        private float _angleInDegrees;
        private Rigidbody _rb;
        private Transform _transform;
        private float _g;
        
        private void Start()
        {
            _g = -Physics.gravity.y;
            _rb = GetComponent<Rigidbody>();
            _collider = GetComponent<Collider>();
            _transform = transform;
            if (CanHitPlayer) _collider.enabled = false;
            GlobalEventManager.OnProjectileAttackerDestroy += DestroyWithEffect;
        }

        public override void Throw(Vector3 targetPosition)
        {
            _audioSource.Play();
            _transform.parent = null;
            _rb.isKinematic = false;
            float angle = _angleInDegrees * Mathf.PI / 180;
            float v = CalculateThrowSpeedForBallisticMove(angle, targetPosition);
            _transform.LookAt(targetPosition);
            if (_transform != null)
                _rb.velocity = _transform.forward * v * Mathf.Cos(angle) +
                    _transform.up * v * Mathf.Sin(angle);
            StartCoroutine(ActivateColliderBeforeThrow());
        }

        private float CalculateThrowSpeedForBallisticMove(float angle, Vector3 targetPosition)
        {
            float distance = Vector3.Distance(targetPosition, _transform.position);
            float v2 = distance * _g / Mathf.Sin(2 * angle);
            float v = Mathf.Sqrt(Mathf.Abs(v2));
            return v;
        }

        private IEnumerator ActivateColliderBeforeThrow()
        {
            yield return new WaitForSeconds(_timeToActiveCollisionBeforeThrow);
            _collider.enabled = true;
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            var collisionGameObject = collision.gameObject;
            if (collisionGameObject.TryGetComponent(out IWeaponVisitor visitor)) Accept(visitor);
            if (collisionGameObject.TryGetComponent(out Player _))
            {
                if (!CanHitPlayer) return;
                GlobalEventManager.SendOnEnemyHit();
                DestroyWithEffect(this);
                return;
            }
            DestroyWithEffect(this);
        }

        public void Accept(IWeaponVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
