using UnityEngine;

namespace Projectile_and_particle
{
    public class Lightning : Projectile
    {
        [SerializeField]
        private GameObject _lightning;
        
        public override void Throw(Vector3 targetPosition)
        {
            _audioSource.Play();
            GlobalEventManager.OnProjectileAttackerDestroy += DestroyWithEffect;
            CanHitPlayer = true;
            transform.LookAt(targetPosition);
            _lightning.SetActive(true);
        }
        
    }
}