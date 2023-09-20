using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

/// <summary>
/// Generate map in player viewing area.
/// </summary>
public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    private Chunk[] chunkPrefabs;

    [SerializeField]
    private Chunk startChunk;

    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private float playerViewDistance;

    private List<Chunk> activeChunks;

    private ObjectPool<Chunk> chunkPool;

    private void Awake()
    {
        activeChunks = new List<Chunk>{startChunk};

        chunkPool = new ObjectPool<Chunk>(OnChunkCreated, OnChunkGot,
            OnChunkReleased, OnChunkDestroyed);
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
            activeChunks.Remove(firstChunk);

            if (firstChunk == startChunk)
            {
                Destroy(startChunk.gameObject);
                return;
            }

            chunkPool.Release(firstChunk);
        }
    }

    private void SpawnChunk(Vector3 beginPosition)
    {
        var newChunk = chunkPool.Get();

        if (newChunk == null)
        {
            return;
        }

        newChunk.Initialize();

        newChunk.transform.localPosition = beginPosition - newChunk.Begin.localPosition;

        activeChunks.Add(newChunk);
    }

    private Chunk OnChunkCreated()
    {
        var chunk = Instantiate(chunkPrefabs[Random.Range(0, chunkPrefabs.Length)], transform);
        return chunk;
    }

    private void OnChunkGot(Chunk chunk)
    {
        chunk.gameObject.SetActive(true);
    }

    private void OnChunkReleased(Chunk chunk)
    {
        chunk.gameObject.SetActive(false);
    }

    private void OnChunkDestroyed(Chunk chunk)
    {
        Destroy(chunk.gameObject);
    }
}