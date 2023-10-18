using UnityEngine;

/// <summary>
/// Ragdoll controller.
/// </summary>
public class Ragdoll
{
    private Rigidbody[] rigidbodies;

    /// <summary>
    /// Initialize ragdoll.
    /// </summary>
    public Ragdoll(Rigidbody[] rigidbodies)
    {
        this.rigidbodies = rigidbodies;

        Deactivate();
    }

    /// <summary>
    /// Activate ragdoll.
    /// </summary>
    public void Activate()
    {
        foreach (var rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = false;
        }
    }

    /// <summary>
    /// Deactivate ragdoll.
    /// </summary>
    public void Deactivate()
    {
        foreach (var rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = true;
        }
    }
}