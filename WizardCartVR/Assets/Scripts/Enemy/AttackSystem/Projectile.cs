using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public event Action Disabled;

    [SerializeField]
    private Rigidbody rigidbody;

    public void Push(Vector3 direction, float force)
    {
        rigidbody.AddForce(direction * force, ForceMode.Impulse);
    }

    private void OnDisable()
    {
        rigidbody.velocity = Vector3.zero;

        Disabled?.Invoke();
    }
}