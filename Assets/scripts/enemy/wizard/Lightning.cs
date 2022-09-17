using System.Collections;
using Unity.VisualScripting;
using UnityEngine;


namespace enemy.wizard
{
    public class Lightning : Projectile
    {
        private RaycastHit hit;
        [SerializeField]
        private Transform lightningTransform;
        [SerializeField] 
        private float particleTime;
        [SerializeField] 
        private float particleDistance;

        private bool _isAttack;
        private Vector3 _targetPosition;
        public override void Throw(Transform target, float angle, float speed)
        {
            _targetPosition = target.position;
            transform.LookAt(_targetPosition);
            lightningTransform.gameObject.SetActive(true);
            _isAttack = true;
            StartCoroutine(SendRay());
        }
        private IEnumerator SendRay()
        {
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(EndRaycastAttack());
            while (_isAttack)
            {
                transform.LookAt(_targetPosition);
                Physics.Raycast(transform.position, transform.forward, out hit, particleDistance);
                if (hit.collider != null)
                    if (hit.collider.CompareTag("Player")) GlobalEventManager.SendOnPlayerHit();
                yield return new WaitForSeconds(0.2f);
            }
        }

        private IEnumerator EndRaycastAttack()
        {
            yield return new WaitForSeconds(particleTime);
            _isAttack = false;
        }
    }
}