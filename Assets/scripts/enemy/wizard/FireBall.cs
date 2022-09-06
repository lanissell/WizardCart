using System.Collections;
using UnityEngine;

namespace enemy.wizzard
{
    public class FireBall : Projectile
    {
        [SerializeField]
        private GameObject fireBallSphere;
        private Collider _fireBallTransform;
        [SerializeField]
        private GameObject explosion;
        [SerializeField]
        private float fireBallCreateDelay;
        private Rigidbody _ballRigidbody;
        private Vector3 _target;
        private float _g;
        private void Start()
        {
            _g = -Physics.gravity.y;
            _target = Vector3.zero;
            _ballRigidbody = GetComponent<Rigidbody>();
            _fireBallTransform = fireBallSphere.GetComponent<Collider>();
            _fireBallTransform.isTrigger = true;
            fireBallSphere.SetActive(false);
            StartCoroutine(ActivateFireBall());
        }

        private IEnumerator ActivateFireBall()
        {
            yield return new WaitForSeconds(fireBallCreateDelay);
            fireBallSphere.SetActive(true);
        }
        private IEnumerator ActivateFireBallCollider()
        {
            yield return new WaitForSeconds(fireBallCreateDelay);
            _fireBallTransform.isTrigger = false;
        }

        public override void Throw(Transform projectileTarget, float angleInDegrees, float speed)
        {
            _ballRigidbody.isKinematic = false;
            _target = projectileTarget.position + new Vector3(0, 2, 0);
            //speed calculation for ballistic flight to target
            var distance = Vector3.Distance(_target, transform.position);
            var angle = angleInDegrees * Mathf.PI / 180;
            var v2 = distance * _g / Mathf.Sin(2 * angle);
            var v = Mathf.Sqrt(Mathf.Abs(v2));
            transform.LookAt(_target);
            if (transform != null)
                _ballRigidbody.velocity = transform.forward * v * Mathf.Cos(angle) +
                                          (transform.up * (v * Mathf.Sin(angle)));
            StartCoroutine(ActivateFireBallCollider());
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.tag.Equals("fireWizard")) return;
            Instantiate(explosion, collision.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
