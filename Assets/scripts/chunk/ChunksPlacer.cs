using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace chunk
{
    public class ChunksPlacer : MonoBehaviour
    {
        public static ChunksPlacer Instance { get; private set; }
        [SerializeField]
        private float generationDistance;
        [SerializeField]
        private Transform player;
        [Header("Chunks")]
        [SerializeField]
        private Chunk firstChunk;
        [SerializeField]
        private Chunk[] forestChunkPrefabs;
        private Chunk[] _chunksForSpawn;
        private Dictionary<int, Chunk[]> _chunks;
        private readonly List<Chunk> _spawnedChunks = new List<Chunk>();
        [Header("ChangeChunkPrefabList")]
        [SerializeField]
        private float minTimeToChangePrefab;
        [SerializeField]
        private float maxTimeToChangePrefab;
        public float moveSpeed;
        private void Awake()
        {
            Instance = this;
        }
        private void Start()
        {
            _spawnedChunks.Add(firstChunk);
            _chunks = new Dictionary<int, Chunk[]>()
            {
                {0, forestChunkPrefabs},
            };
            _chunksForSpawn = _chunks[0];
            StartCoroutine(ModGenerationDist(3));

        }

        private void Update()
        {
            if (Vector3.Distance(_spawnedChunks[^1].end.position, player.position) < generationDistance)
            {
                SpawnChunk();
            }
            transform.Translate(-transform.forward * (Time.deltaTime * moveSpeed));
        }

        private void SpawnChunk()
        {
            var newChunk = Instantiate(_chunksForSpawn[Random.Range(0, _chunksForSpawn.Length)], transform);
            newChunk.rotationPoint.rotation = new Quaternion(0, 180 * Random.Range(0, 2), 0, 0);
            newChunk.transform.position = _spawnedChunks[^1].end.position - newChunk.begin.localPosition;
            _spawnedChunks.Add(newChunk);
            if (!(Vector3.Distance(_spawnedChunks[0].end.position, player.position) > generationDistance)) return;
            Destroy(_spawnedChunks[0].gameObject);
            _spawnedChunks.RemoveAt(0);
        }
        private IEnumerator ModGenerationDist(float mod)
        {
            generationDistance /= mod;
            yield return new WaitForSeconds(1);
            generationDistance *= mod;
        }

        private IEnumerator ChangeChunkForSpawn()
        {
            yield return new WaitForSeconds(Random.Range(minTimeToChangePrefab,maxTimeToChangePrefab));
        }
    }
}