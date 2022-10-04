using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace enemy.wizard
{
    [RequireComponent(typeof(Rigidbody))]
    public class FireBall : MonoBehaviour, IProjectile
    {
        [SerializeField]
        private float _createDelay;
        [SerializeField]
        private GameObject _sphere;
        private Collider _collider;
        [SerializeField]
        private GameObject _explosion;
        [FormerlySerializedAs("angleInDegrees")] [SerializeField]
        private float _angleInDegrees;
        private Rigidbody _rb;
        private float _g;
        private void Start()
        {
            _g = -Physics.gravity.y;
            _rb = GetComponent<Rigidbody>();
            _collider = GetComponent<Collider>();
            StartCoroutine(ActivateFireBallSphere());
        }

        private IEnumerator ActivateFireBallSphere()
        {
            yield return new WaitForSeconds(_createDelay);
            _sphere.SetActive(true);
        }

        public void Throw(Vector3 targetPosition)
        {
            transform.parent = null;
            _rb.isKinematic = false;
            float angle = _angleInDegrees * Mathf.PI / 180;
            float v = CalculateThrowSpeedForBallisticMove(angle, targetPosition);
            transform.LookAt(targetPosition);
            if (transform != null)
                _rb.velocity = transform.forward * v * Mathf.Cos(angle) +
                                          transform.up * v * Mathf.Sin(angle);
            StartCoroutine(ActivateCollider());
        }

        private float CalculateThrowSpeedForBallisticMove(float angle, Vector3 targetPosition)
        {
            float distance = Vector3.Distance(targetPosition, transform.position);
            float v2 = distance * _g / Mathf.Sin(2 * angle);
            float v = Mathf.Sqrt(Mathf.Abs(v2));
            return v;
        }
        private IEnumerator ActivateCollider()
        {
            yield return new WaitForSeconds(_createDelay);
            _collider.isTrigger = false;
        }

        private void OnCollisionEnter(Collision collision)
        {
            Instantiate(_explosion, collision.transform);
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("MainCamera")) GlobalEventManager.SendOnPlayerHit();
        }
    }
}
