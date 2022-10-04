using System.Linq;
using props;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRGrabInteractable), typeof(SpeedLimit), typeof(Prop))]
public class StickInTarget : MonoBehaviour
{
    [SerializeField] private Collider _sharp;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void DestroyUnusedComponents()
    {
        Destroy(gameObject.GetComponent<StickInTarget>());
        Destroy(gameObject.GetComponent<XRGrabInteractable>());
        Destroy(gameObject.GetComponent<SpeedLimit>());
        Destroy(gameObject.GetComponent<Prop>());
        Destroy(_rb);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<StickyObject>() == null) return;
        if (collision.contacts.Any(c => c.thisCollider != _sharp)) return;
        Transform colTransform = collision.transform;
        transform.position = collision.contacts[0].point;
        transform.parent = colTransform;
        DestroyUnusedComponents();
    }
    
}
