using Unity.Mathematics;
using UnityEngine;

namespace Projectile_and_particle
{
    [RequireComponent(typeof(AudioSource))]
    public abstract class Projectile: MonoBehaviour
    {
        [HideInInspector]
        public Transform Parent;
        protected bool CanHitPlayer = false;
        [SerializeField]
        protected AudioSource _audioSource;
        [SerializeField]
        private GameObject _explosion;
        
        public abstract void Throw(Vector3 targetPosition);
        
        public void SetAbilityToHitPlayer(bool canHitPlayer) => CanHitPlayer = canHitPlayer;

        protected void DestroyWithEffect(Transform diedTransform)
        {
            if (diedTransform != Parent) return;
            GlobalEventManager.OnEnemyDie -= DestroyWithEffect;
            Instantiate(_explosion, transform.position, quaternion.identity);
            Destroy(gameObject);
        }
        
    }
}
