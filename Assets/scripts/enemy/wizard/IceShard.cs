using UnityEngine;

namespace enemy.wizard
{
    public class IceShard : Projectile
    {
        private ParticleSystem _particleSystem;
        [SerializeField] private ParticleSystem chargeEffect;
        private void Start()
        {
            _particleSystem = GetComponent<ParticleSystem>();
            Destroy(Instantiate(chargeEffect,transform), 3f);
        }
        
        public override void Throw(Transform target, float angle, float speed)
        {
            _particleSystem.Play();
            transform.parent = null;
        }

        private void OnParticleCollision(GameObject other)
        {
            if (other.tag.Equals("Player"))
                GlobalEventManager.SendOnPlayerHit();
        }
    }
}
