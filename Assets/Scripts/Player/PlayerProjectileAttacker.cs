using enemy;
using Projectile_and_particle;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerProjectileAttacker : MonoBehaviour
{
    [SerializeField]
    private Projectile _projectilePrefab;
    private Projectile _projectile;

    public void CreateProjectile(string gestureName)
    {
        if (gestureName.Equals("Circle")) _projectile = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
        if (_projectile == null) return;
        if (_projectile.TryGetComponent(out XRGrabInteractable grabInteractable)) grabInteractable.enabled = true;
    }
}
