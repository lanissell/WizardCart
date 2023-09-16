using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class MapGenerator : MonoBehaviour
{
    private const float ChunkFlipAngle = 180.0f;

    [SerializeField]
    private Chunk[] chunkPrefabs;

    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private float playerViewDistance;

    private List<Chunk> activeChunks;

    private void Awake()
    {
        activeChunks = new List<Chunk>();
    }

    private void Start()
    {
        SpawnChunk(Vector3.zero);
    }

    private void Update()
    {
        if (activeChunks.Count == 0)
        {
            return;
        }

        var lastChunk = activeChunks[^1];

        if (Vector3.Distance(lastChunk.transform.position, playerTransform.position) < playerViewDistance)
        {
            SpawnChunk(lastChunk.End.position);
        }

        var firstChunk = activeChunks[0];

        if (Vector3.Distance(firstChunk.Begin.position, playerTransform.position) > playerViewDistance)
        {
            Destroy(firstChunk.gameObject);
            activeChunks.Remove(firstChunk);
        }
    }

    private void SpawnChunk(Vector3 beginPosition)
    {
        var newChunk = Instantiate(chunkPrefabs[Random.Range(0, chunkPrefabs.Length)], transform);

        newChunk.transform.localPosition = beginPosition - newChunk.Begin.localPosition;

        var rotateAngle = ChunkFlipAngle * Mathf.Round(Random.Range(0.0f, 1.0f));
        newChunk.RotationPoint.Rotate(Vector3.up, rotateAngle);

        activeChunks.Add(newChunk);
    }
}