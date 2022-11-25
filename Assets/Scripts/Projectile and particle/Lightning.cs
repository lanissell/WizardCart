using UnityEngine;

namespace Projectile_and_particle
{
    public class Lightning : Projectile
    {
        [SerializeField]
        private float _destroyAfterTrowTime;
        [SerializeField]
        private GameObject _lightning;

        private void Start()
        {
            GlobalEventManager.OnEnemyDie += DestroyWithEffect;
        }

        public override void Throw(Vector3 targetPosition)
        {
            CanHitPlayer = true;
            transform.LookAt(targetPosition);
            _lightning.SetActive(true);
            _audioSource.Play();
            Destroy(gameObject, _destroyAfterTrowTime);
        }
        
    }
}