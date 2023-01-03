using ProjectilesAndParticles;
using UnityEngine;

namespace Projectile_and_particle
{
    [RequireComponent(typeof(ParticleSystem))]
    public class IceShard : Projectile
    {
        [SerializeField]
        private float _destroyAfterTrowTime;
        [SerializeField] 
        private ParticleSystem _chargeEffect;
        private ParticleSystem _particleSystem;

        private void Start()
        {
            _particleSystem = GetComponent<ParticleSystem>();
            Destroy(Instantiate(_chargeEffect,transform), 3f);
        }
        
        public override void Throw(Vector3 targetPosition)
        {
            _audioSource.Play();
            _particleSystem.Play();
            transform.parent = null;
            Destroy(gameObject, _destroyAfterTrowTime);
        }

    }
}
