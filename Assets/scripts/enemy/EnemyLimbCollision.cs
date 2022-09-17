using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace enemy
{
    [RequireComponent(typeof(StikedObject))]
    public class EnemyLimbCollision : MonoBehaviour
    {
        public Ragdoll activateRagdoll;
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("blade")) return;
            activateRagdoll.SendOnChildCollision();
        }
    }
}
