using System;
using UnityEngine;
namespace Chunk
{
    public class ObstaclePlayerCollision : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player _)) GlobalEventManager.SendOnPlayerHit();
        }
    }
}
