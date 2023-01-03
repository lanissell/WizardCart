using System.Collections;
using ProjectilesAndParticles;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies
{
    public class ProjectileAttacker : MonoBehaviour
    {
        [Header("Projectile")]
        [SerializeField]
        private Projectile _projectilePrefab;
        private Projectile _projectileObject;
        [SerializeField]
        private Transform _spawnPoint;
        
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
            Enemy.OnEnemyDied += DestroyAttacker;
            _animator = GetComponent<Animator>();
            _attackDist = Random.Range(_attackDist / 1.5f, _attackDist);
            _transform = transform;
            _targetPosition = Camera.main.transform.position;
        }

        private void Update()
        {
            if (!CheckAttackPossibility(Vector3.Distance(_transform.position, _targetPosition))) return;
            Attack();
        }
        
        private bool CheckAttackPossibility(float dist)
        {
            if (_isAttack) return false;
            return dist < _attackDist;
        }

        private void Attack()
        {
            _isAttack = true;
            _animator.SetTrigger(Atk);
            CreateProjectile();
            StartCoroutine(AttackDelay());
        }
        
        private void CreateProjectile()
        {
            _projectileObject = Instantiate(_projectilePrefab, _spawnPoint);
            _projectileObject.SetAbilityToHitPlayer(true);
            _projectileObject.Parent = _transform;
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

        private void DestroyAttacker(Transform destroyTransform)
        {
            if (destroyTransform != _transform) return;
            Enemy.OnEnemyDied -= DestroyAttacker;
            Destroy(this);
        }
    }
}
