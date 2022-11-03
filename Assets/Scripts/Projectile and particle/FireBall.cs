using System.Collections;
using Enemy;
using UnityEngine;
using Weapons;

namespace Projectile_and_particle
{
    [RequireComponent(typeof(Rigidbody), typeof(ParticleSystem), typeof(Collider))]
    public class FireBall : Projectile, IWeapon
    {
        private Collider _collider;
        [SerializeField]
        private float _timeToActiveCollisionBeforeThrow;
        [SerializeField]
        private GameObject _explosion;
        [SerializeField]
        private float _angleInDegrees;
        private Rigidbody _rb;
        private float _g;
        private Transform _transform;
        
        private void Start()
        {
            _g = -Physics.gravity.y;
            _rb = GetComponent<Rigidbody>();
            _collider = GetComponent<Collider>();
            _transform = transform;
            if (CanHitPlayer) _collider.enabled = false;
        }

        public override void Throw(Vector3 targetPosition)
        {
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
                GlobalEventManager.SendOnPlayerHit();
                DestroyWithEffect(collision);
                return;
            }
            DestroyWithEffect(collision);
        }

        private void DestroyWithEffect(Collision collision)
        {
            Instantiate(_explosion, collision.contacts[0].point, Quaternion.identity);
            Destroy(gameObject);
        }

        public void Accept(IWeaponVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
