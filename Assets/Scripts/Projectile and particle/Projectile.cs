using Unity.Mathematics;
using UnityEngine;

namespace Projectile_and_particle
{
    [RequireComponent(typeof(AudioSource))]
    public abstract class Projectile: MonoBehaviour
    {
        protected bool CanHitPlayer = false;
        [SerializeField]
        protected AudioSource _audioSource;
        [SerializeField]
        private GameObject _explosion;
        public abstract void Throw(Vector3 targetPosition);
        
        public void SetCanHitPlayer(bool canHitPlayer) => CanHitPlayer = canHitPlayer;

        protected void DestroyWithEffect(Projectile projectile)
        {
            if (projectile != this) return;
            GlobalEventManager.OnProjectileAttackerDestroy -= DestroyWithEffect;
            Instantiate(_explosion, transform.position, quaternion.identity);
            Destroy(gameObject);
        }
        
    }
}
