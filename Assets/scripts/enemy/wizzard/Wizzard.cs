using System.Collections;
using UnityEngine;

namespace enemy.wizzard
{
    [RequireComponent(typeof(ActivateRagdoll))]
    public class Wizzard : MonoBehaviour
    {
        [Header("Projectile")]
        [SerializeField]
        private GameObject projectilePrefab;
        private GameObject _projectileObject;
        [Range(45, 60)]
        [SerializeField]
        private float maxProjectileAngleOrSpeed;
        [Range(30, 45)]
        [SerializeField]
        private float minProjectileAngleOrSpeed;
        private float _projectileAngleOrSpeed;
        [SerializeField]
        private Transform projectileSpawnPoint;
        [Header("Attack")]
        [SerializeField]
        private float vewDist;
        [SerializeField]
        private float attackDist;
        [SerializeField]
        private float attackDelay;
        private bool _isAttack;
        private Animator _animator;
        private Transform _target;
        [SerializeField]
        [Range(50,300)]
        private float deleteDist;
        private ActivateRagdoll _activateRagdoll;
        private static readonly int Atk = Animator.StringToHash("atk");

        private void Start()
        {
            _activateRagdoll = GetComponent<ActivateRagdoll>();
            _animator = GetComponent<Animator>();
            _target = GameObject.FindWithTag("Player").transform;
            attackDist = Random.Range(attackDist / 1.5f, attackDist);
            _projectileAngleOrSpeed = Random.Range(minProjectileAngleOrSpeed, maxProjectileAngleOrSpeed);
        }

        private void Update()
        {
            var dist = Vector3.Distance(transform.position, _target.position);
            if (dist < vewDist)
            {
                var position = _target.position;
                transform.LookAt(new Vector3(position.x, 0, position.z));
                if (!_isAttack)
                {
                    if (dist < attackDist) StartCoroutine(Attack());
                }
            }
            if (_isAttack && dist > deleteDist) Destroy(gameObject);
        }

        private IEnumerator Attack()
        {
            _isAttack = true;
            _projectileObject = Instantiate(projectilePrefab, projectileSpawnPoint.position,Quaternion.identity,projectileSpawnPoint);
            yield return new WaitForSeconds(1);
            _animator.SetTrigger(Atk);
            yield return new WaitForSeconds(attackDelay);
            _isAttack = false;
        }

        private void ThrowProjectile()
        {
            _projectileObject.transform.parent = null;
            _projectileObject.transform.position = projectileSpawnPoint.position;
            _projectileObject.GetComponent<Projectile>().Throw(_target, _projectileAngleOrSpeed);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("sword")) return;
            if (other.attachedRigidbody == null) return;
            //if (other.attachedRigidbody.velocity.magnitude >= 2)
            _activateRagdoll.ActivateRagdollMethod();
        }
    }
}
