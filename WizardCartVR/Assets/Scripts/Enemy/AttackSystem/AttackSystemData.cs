using UnityEngine;

[CreateAssetMenu(fileName = "AttackSystemData", menuName = "ScriptableObjects/AttackSystemData")]
public class AttackSystemData : ScriptableObject
{
    [SerializeField]
    private Projectile projectilePrefab;

    public Projectile ProjectilePrefab => projectilePrefab;

    [SerializeField]
    private float projectilePushForce;

    public float ProjectilePushForce => projectilePushForce;

    [SerializeField]
    private float countPerShot;

    public float CountPerShot => countPerShot;

    [SerializeField]
    private float shotDelay;

    public float ShotDelay => shotDelay;

    [SerializeField]
    private float attackDistance;

    public float AttackDistance => attackDistance;
}