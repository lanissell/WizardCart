using UnityEngine;

namespace Projectile_and_particle
{
    public class Lightning : Projectile
    {
        private RaycastHit hit;
        [SerializeField]
        private GameObject _lightning;
       
        public override void Throw(Vector3 targetPosition)
        {
            CanHitPlayer = true;
            transform.LookAt(targetPosition);
            _lightning.SetActive(true);
        }
        
    }
}