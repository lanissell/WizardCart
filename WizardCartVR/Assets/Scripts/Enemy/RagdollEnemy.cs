using UnityEngine;

public class RagdollEnemy : Enemy
{
    [SerializeField]
    private Rigidbody[] ragdollRigidbodies;

    private Ragdoll ragdoll;

    public override void Initialize()
    {
        base.Initialize();

        ragdoll = new Ragdoll(ragdollRigidbodies);
    }
}