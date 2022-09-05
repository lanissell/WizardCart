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

    private IEnumerator Start()
    {
        _xrGrab = GetComponent<XRGrabInteractable>();
        _rb = GetComponent<Rigidbody>();
        _speedLimit = GetComponent<SpeedLimit>();
        //_rb.isKinematic = true;
        yield return new WaitForSeconds(2);
        //_rb.isKinematic = false;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<StikedObject>() == null) return;
        if (collision.contacts.Any(c => c.thisCollider != sharp)) return;
        print(_rb.velocity.magnitude);
        transform.rotation = Quaternion.FromToRotation(transform.position, collision.transform.position) * Quaternion.Euler(-90,0,0);
        transform.position = collision.contacts[0].point;
        transform.parent = collision.transform;
        var sharpLength = _rb.velocity.magnitude;
        if (sharpLength < 8) sharpLength = 8;
        transform.Translate(sharpDirection.up / sharpLength);
        if (_xrGrab != null)Destroy(_xrGrab);
        if (_speedLimit != null) Destroy(_speedLimit);
        if (_rb != null) Destroy(_rb);
    }
}
