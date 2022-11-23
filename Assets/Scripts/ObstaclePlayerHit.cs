using System;
using UnityEngine;
namespace Chunk
{
    public class ObstaclePlayerHit : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player _)) GlobalEventManager.SendOnEnemyHit();
        }
    }
}
