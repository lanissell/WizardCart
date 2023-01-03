using Unity.Mathematics;
using UnityEngine;

namespace ProjectilesAndParticles
{
    [RequireComponent(typeof(AudioSource))]
    public abstract class Projectile: HittingPlayer
    {
        [HideInInspector]
        public Transform Parent;
        protected bool canHitPlayer = false;
        [SerializeField]
        protected AudioSource _audioSource;
        [SerializeField]
        private GameObject _explosion;

        private void Awake()
        {
            Enemies.Enemy.OnEnemyDied += DestroyWithEffect;
        }

        public abstract void Throw(Vector3 targetPosition);
        
        public void SetAbilityToHitPlayer(bool canHit) => canHitPlayer = canHit;

        protected void DestroyWithEffect(Transform diedTransform)
        {
            if (diedTransform != Parent) return;
            Enemies.Enemy.OnEnemyDied -= DestroyWithEffect;
            Instantiate(_explosion, transform.position, quaternion.identity);
            Destroy(gameObject);
        }
        
    }
}
