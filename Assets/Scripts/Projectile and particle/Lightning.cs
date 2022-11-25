using UnityEngine;

namespace Projectile_and_particle
{
    public class Lightning : Projectile
    {
        [SerializeField]
        private GameObject _lightning;

        private void Start()
        {
            GlobalEventManager.OnEnemyDie += DestroyWithEffect;
        }

        public override void Throw(Vector3 targetPosition)
        {
            _audioSource.Play();
            CanHitPlayer = true;
            transform.LookAt(targetPosition);
            _lightning.SetActive(true);
        }
        
    }
}