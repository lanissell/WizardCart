using ProjectilesAndParticles;
using UnityEngine;

namespace Projectile_and_particle
{
    public class Lightning : Projectile
    {
        [SerializeField]
        private float _destroyAfterTrowTime;
        [SerializeField]
        private GameObject _lightning;

        public override void Throw(Vector3 targetPosition)
        {
            canHitPlayer = true;
            transform.LookAt(targetPosition);
            _lightning.SetActive(true);
            _audioSource.Play();
            Destroy(gameObject, _destroyAfterTrowTime);
        }
        
    }
}