using System.Collections;
using System.Collections.Generic;
using System.Linq;
using props;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class StikInTarget : MonoBehaviour
{
    [SerializeField] private Collider sharp;
    [SerializeField] private Transform sharpDirection;
    private XRGrabInteractable _xrGrab;
    private Rigidbody _rb;
    private SpeedLimit _speedLimit;

    private void Start()
    {
        _xrGrab = GetComponent<XRGrabInteractable>();
        _rb = GetComponent<Rigidbody>();
        _speedLimit = GetComponent<SpeedLimit>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<StikedObject>() == null) return;
        if (collision.contacts.Any(c => c.thisCollider != sharp)) return;
        var colTransform = collision.transform;
        transform.rotation = Quaternion.FromToRotation(transform.position, colTransform.position) * Quaternion.Euler(-90,0,0);
        transform.position = collision.contacts[0].point;
        transform.parent = colTransform;
        if (_xrGrab != null)Destroy(_xrGrab);
        if (_speedLimit != null) Destroy(_speedLimit);
        if (_rb != null) _rb.isKinematic = true;
    }
}
