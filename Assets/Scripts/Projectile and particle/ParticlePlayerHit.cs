using UnityEngine;

namespace Projectile_and_particle
{
    public class ParticlePlayerHit : MonoBehaviour
    {
        private void OnParticleCollision(GameObject other)
        {
            if (other.TryGetComponent(out Player _)) GlobalEventManager.SendOnEnemyHit();
        }
    }
}
