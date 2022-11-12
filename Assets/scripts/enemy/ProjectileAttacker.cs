using System.Collections;
using Projectile_and_particle;
using UnityEngine;
using UnityEngine.Serialization;

namespace enemy
{
    public class ProjectileAttacker : MonoBehaviour
    {
        [Header("Projectile")]
        [SerializeField]
        private Projectile _projectilePrefab;
        private Projectile _projectileObject;
        [FormerlySerializedAs("_spawnPoint")] [SerializeField]
        private Transform _projectileSpawnPoint;
        [Header("Attack")]
        [SerializeField]
        private float _attackDist;
        [SerializeField]
        private float _attackDelay;
        private bool _isAttack;
        private Vector3 _targetPosition;
        private Animator _animator;
        private Transform _transform;
        private static readonly int Atk = Animator.StringToHash("atk");
        
        private void Start()
        {
            _animator = GetComponent<Animator>();
            _attackDist = Random.Range(_attackDist / 1.5f, _attackDist);
            _transform = transform;
            _targetPosition = Camera.main.transform.position;
        }

        private void Update()
        {
            if (CheckAttackPossibility(Vector3.Distance(_transform.position, _targetPosition)))
            {
                Attack();
            }
        }

        private void Attack()
        {
            _isAttack = true;
            _animator.SetTrigger(Atk);
            CrateProjectile();
            StartCoroutine(AttackDelay());
        }

        private bool CheckAttackPossibility(float dist)
        {
            if (_isAttack) return false;
            return dist < _attackDist;
        }

        private void CrateProjectile()
        {
            _projectileObject = Instantiate(_projectilePrefab, _projectileSpawnPoint);
            _projectileObject.SetCanHitPlayer(true);
        }

        private IEnumerator AttackDelay()
        {
            yield return new WaitForSeconds(_attackDelay);
            _isAttack = false;
        }
        

        private void ThrowProjectile() //used in animation event
        {
            _projectileObject.Throw(_targetPosition);
        }
    }
}
