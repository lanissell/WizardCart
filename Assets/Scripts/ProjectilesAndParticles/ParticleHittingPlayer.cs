using UnityEngine;

namespace ProjectilesAndParticles
{
    public class ParticleHittingPlayer : HittingPlayer
    {
        private void OnParticleCollision(GameObject other)
        {
            if (other.TryGetComponent(out Player _)) HitPlayer();
        }
    }
}
