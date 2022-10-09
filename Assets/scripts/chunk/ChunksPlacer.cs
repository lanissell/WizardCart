using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace chunk
{
    public class ChunksPlacer : MonoBehaviour, INeedBeSingle
    {
        public static ChunksPlacer Instance { get; private set; }
        public float _generationDistance;
        private Transform _player;
        [Header("Chunks")]
        [SerializeField]
        private Chunk _firstChunk; 
        [SerializeField]
        private Chunk[] _forestChunkPrefabs;
        private Chunk[] _chunksForSpawn;
        private Dictionary<int, Chunk[]> _chunks;
        private readonly List<Chunk> _spawnedChunks = new List<Chunk>();
        private void Awake()
        {
            Instance = this;
        }
        private void Start()
        {
            _spawnedChunks.Add(_firstChunk);
            _chunks = new Dictionary<int, Chunk[]>()
            {
                {0, _forestChunkPrefabs},
            };
            _chunksForSpawn = _chunks[0];
            if (Camera.main != null) _player = Camera.main.transform;
            StartCoroutine(ModGenerationDist(3));

        }

        private void Update()
        {
            if (Vector3.Distance(_spawnedChunks[^1].End.position, _player.position) < _generationDistance)
            {
                SpawnChunk();
            }
        }

        private void SpawnChunk()
        {
            var newChunk = Instantiate(_chunksForSpawn[Random.Range(0, _chunksForSpawn.Length)], transform);
            newChunk.RotationPoint.rotation = new Quaternion(0, 180 * Random.Range(0, 2), 0, 0);
            newChunk.transform.position = _spawnedChunks[^1].End.position - newChunk.Begin.localPosition;
            _spawnedChunks.Add(newChunk);
            if (!(Vector3.Distance(_spawnedChunks[0].End.position, _player.position) > _generationDistance)) return;
            Destroy(_spawnedChunks[0].gameObject);
            _spawnedChunks.RemoveAt(0);
        }
        
        private IEnumerator ModGenerationDist(float mod)
        {
            _generationDistance /= mod;
            yield return new WaitForSeconds(1);
            _generationDistance *= mod;
        }
        
    }
}