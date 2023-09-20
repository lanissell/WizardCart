using System;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Map chunk.
/// </summary>
public class Chunk : MonoBehaviour
{
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

    [SerializeField]
    private GameObject[] plates;

    [SerializeField]
    private GameObject activePlate;

    [SerializeField]
    private GameObject[] borders;

    [SerializeField]
    private GameObject activeBorder;

    [SerializeField]
    private GameObject[] fillings;

    [SerializeField]
    private GameObject activeFilling;
    
    public void Initialize()
    {
        activePlate.SetActive(false);
        activeBorder.SetActive(false);
        activeFilling.SetActive(false);

        activePlate = ActivateRandomVariant(plates);
        activeBorder = ActivateRandomVariant(borders);
        activeFilling = ActivateRandomVariant(fillings);
    }

    private GameObject ActivateRandomVariant(GameObject[] variants)
    {
        var variant = variants[Random.Range(0, variants.Length)];

        variant.SetActive(true);

        return variant;
    }
}