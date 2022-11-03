using System.Linq;
using Enemy;
using props;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Weapons;

public class StickInTarget : MonoBehaviour
{
    [SerializeField] private Collider _sharp;
    private Rigidbody _rb;
    private Transform _transform;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _transform = transform;
    }

    private void DestroyUnusedComponents()
    {
        Destroy(this);
        if (TryGetComponent(out XRGrabInteractable grabInteractable)) Destroy(grabInteractable);
        if (TryGetComponent(out Prop prop)) Destroy(prop);
        if (TryGetComponent(out SpeedLimit speedLimit)) Destroy(speedLimit);
        if (TryGetComponent(out MagneticWeapon magneticWeapon)) Destroy(magneticWeapon);
        Destroy(_rb);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<StickyObject>() == null) return;
        if (collision.contacts.Any(c => c.thisCollider == _sharp))
        {
            Stick(collision);
            DestroyUnusedComponents();
        }
    }

    private void Stick(Collision collision)
    {
        _transform.parent = collision.transform;
        _transform.position = collision.contacts[0].point;
    }
    
}
