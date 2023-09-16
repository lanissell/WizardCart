using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField]
    private Transform begin;

    public Transform Begin => begin;

    [SerializeField]
    private Transform end;

    public Transform End => end;

    [SerializeField]
    private Transform rotationPoint;

    public Transform RotationPoint => rotationPoint;
}