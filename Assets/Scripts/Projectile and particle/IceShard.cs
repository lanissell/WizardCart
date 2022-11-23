using UnityEngine;

namespace Projectile_and_particle
{
    public class IceShard : Projectile
    {
        private ParticleSystem _particleSystem;
        [SerializeField] 
        private ParticleSystem _chargeEffect;

        private void Start()
        {
            _particleSystem = GetComponent<ParticleSystem>();
            Destroy(Instantiate(_chargeEffect,transform), 3f);
            GlobalEventManager.OnProjectileAttackerDestroy += DestroyWithEffect;
        }
        
        public override void Throw(Vector3 targetPosition)
        {
            _audioSource.Play();
            _particleSystem.Play();
            transform.parent = null;
            Destroy(gameObject, 5f);
        }

        
    }
}
