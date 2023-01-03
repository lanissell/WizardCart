using UnityEngine;

public class ObstacleHittingPlayer : HittingPlayer
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player _)) HitPlayer();
    }
}