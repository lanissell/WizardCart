using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace enemy
{
    public class ProjectileAttacker : MonoBehaviour
    {
        [Header("Projectile")]
        [SerializeField]
        private GameObject _projectilePrefab;
        private IProjectile _projectileObject;
        [SerializeField]
        private Transform _projectileSpawnPoint;
        [SerializeField] 
        private float _timeToCreateProjectile = 1;
        
        [Header("Attack")]
        [SerializeField]
        private float _attackDist;
        [SerializeField]
        private float _attackDelay;
        private bool _isAttack;
        private Transform _target;
        private Animator _animator;
        
        private static readonly int Atk = Animator.StringToHash("atk");
        private void Start()
        {
            _animator = GetComponent<Animator>();
            _attackDist = Random.Range(_attackDist / 1.5f, _attackDist);
        }

        public void StartAttackCoroutine(float dist, Transform target)
        {
            if (_isAttack) return;
            if (dist > _attackDist) return;
            _target = target;
            StartCoroutine(Attack());
        }

        private IEnumerator Attack()
        {
            _isAttack = true;
            _projectileObject = Instantiate(_projectilePrefab, _projectileSpawnPoint).GetComponent<IProjectile>();
            yield return new WaitForSeconds(_timeToCreateProjectile);
            _animator.SetTrigger(Atk);
            yield return new WaitForSeconds(_attackDelay);
            _isAttack = false;
        }

        private void ThrowProjectile() //used in animation event
        {
            _projectileObject.Throw(_target.position);
        }
    }
}
