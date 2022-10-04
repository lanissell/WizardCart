using UnityEngine;

namespace enemy.wizard
{
    public class ParticlePlayerCollision : MonoBehaviour
    {
        private void OnParticleCollision(GameObject other)
        {
            if (other.tag.Equals("Player"))
                GlobalEventManager.SendOnPlayerHit();
        }
    }
}
