using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace enemy
{
    public class EnemyCollisionWithWeapon : MonoBehaviour
    {
        public ActivateRagdoll activateRagdoll;
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("blade")) return;
            activateRagdoll.childCollision.Invoke();
        }
    }
}
