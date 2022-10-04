using UnityEngine;

namespace enemy
{
    [RequireComponent(typeof(StickyObject))]
    public class EnemyLimbCollision : MonoBehaviour
    {
        public Ragdoll ActivateRagdoll;
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("blade")) return;
            ActivateRagdoll.SendOnChildCollision();
        }
    }
}
