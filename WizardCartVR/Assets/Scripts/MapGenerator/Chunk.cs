using System;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Map chunk.
/// </summary>
public class Chunk : MonoBehaviour
{
    private const float FlipAngle = 180.0f;

    [SerializeField]
    private Transform begin;

    /// <summary>
    /// Begin point.
    /// </summary>
    public Transform Begin => begin;

    [SerializeField]
    private Transform end;

    /// <summary>
    /// End point.
    /// </summary>
    public Transform End => end;

    [NonReorderable]
    [SerializeField]
    private ChunkPart[] parts;

    private bool isFlipped;

    /// <summary>
    /// Initialize chunk.
    /// </summary>
    public void Initialize()
    {
        if (isFlipped)
        {
            Flip();
        }

        foreach (var part in parts)
        {
            part.ActivateRandomVariant();
        }
    }

    /// <summary>
    /// Rotate chunk 180 along the Y axis.
    /// </summary>
    public void Flip()
    {
        isFlipped = !isFlipped;

        float rotateAngle = FlipAngle;

        if (!isFlipped)
        {
            rotateAngle *= -1;
        }

        transform.Rotate(Vector3.up, rotateAngle);

        (end, begin) = (begin, end);
    }
}

/// <summary>
/// Chunk part with different variants.
/// </summary>
[Serializable]
public class ChunkPart
{
    [SerializeField]
    private GameObject activeVariant;

    [NonReorderable]
    [SerializeField]
    private GameObject[] variants;

    /// <summary>
    /// Choose random variant of chunk part.
    /// </summary>
    public void ActivateRandomVariant()
    {
        activeVariant.SetActive(false);

        var variant = variants[Random.Range(0, variants.Length)];

        variant.SetActive(true);

        activeVariant = variant;
    }
}