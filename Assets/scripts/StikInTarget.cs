using System.Linq;
using UnityEngine;
public class StikInTarget : MonoBehaviour
{
    [SerializeField] private Collider sharp;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<StikedObject>() == null) return;
        if (collision.contacts.Any(c => c.thisCollider != sharp)) return;
        var colTransform = collision.transform;
        transform.rotation = Quaternion.FromToRotation(transform.position, colTransform.position) * Quaternion.Euler(-90,0,0);
        transform.position = collision.contacts[0].point;
        transform.parent = colTransform;
        if (_rb != null) _rb.isKinematic = true;
    }
}
