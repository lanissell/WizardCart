using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace enemy
{
    public class ProjectileAttacker : MonoBehaviour
    {
        [Header("Projectile")]
        [SerializeField]
        private Projectile projectilePrefab;
        private Projectile _projectileObject;
        [Range(45, 60)]
        [SerializeField]
        private float projectileAngle;
        [SerializeField]
        private float projectileSpeed;
        [SerializeField]
        private Transform projectileSpawnPoint;
        [SerializeField] 
        private float timeToCreateProjectile = 1;
        
        [Header("Attack")]
        [SerializeField]
        private float attackDist;
        [SerializeField]
        private float attackDelay;
        private bool _isAttack;
        private Transform _target;
        private Animator _animator;
        
        private static readonly int Atk = Animator.StringToHash("atk");
        private void Start()
        {
            _animator = GetComponent<Animator>();
            attackDist = Random.Range(attackDist / 1.5f, attackDist);
        }

        public void StartAttack(float dist, Transform target)
        {
            if (_isAttack) return;
            if (dist > attackDist) return;
            _target = target;
            StartCoroutine(Attack());
        }

        private IEnumerator Attack()
        {
            _isAttack = true;
            _projectileObject = Instantiate(projectilePrefab, projectileSpawnPoint.position,Quaternion.identity,projectileSpawnPoint);
            yield return new WaitForSeconds(timeToCreateProjectile);
            _animator.SetTrigger(Atk);
            yield return new WaitForSeconds(attackDelay);
            _isAttack = false;
        }

        private void ThrowProjectile()
        {
            var projectileTransform = _projectileObject.transform;
            projectileTransform.parent = null;
            projectileTransform.position = projectileSpawnPoint.position;
            _projectileObject.Throw(_target, projectileAngle, projectileSpeed);
        }
    }
}
