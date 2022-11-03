using UnityEngine;

namespace Projectile_and_particle
{
    public abstract class Projectile: MonoBehaviour
    {
        protected bool CanHitPlayer = false;
        
        public abstract void Throw(Vector3 targetPosition);
        
        public void SetCanHitPlayer(bool canHitPlayer) => CanHitPlayer = canHitPlayer;

    }
}
