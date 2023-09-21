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

    [Header("Plates")]
    [SerializeField]
    private GameObject[] plates;

    [SerializeField]
    private GameObject activePlate;

    [Header("Borders")]
    [SerializeField]
    private GameObject[] borders;

    [SerializeField]
    private GameObject activeBorder;

    [Header("Filling")]
    [SerializeField]
    private GameObject[] fillings;

    [SerializeField]
    private GameObject activeFilling;

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

        activePlate.SetActive(false);
        activeBorder.SetActive(false);
        activeFilling.SetActive(false);

        activePlate = ActivateRandomVariant(plates);
        activeBorder = ActivateRandomVariant(borders);
        activeFilling = ActivateRandomVariant(fillings);
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

    private GameObject ActivateRandomVariant(GameObject[] variants)
    {
        var variant = variants[Random.Range(0, variants.Length)];

        variant.SetActive(true);

        return variant;
    }
}