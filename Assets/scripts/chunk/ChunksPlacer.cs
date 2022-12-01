using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace chunk
{
    public class ChunksPlacer : MonoBehaviour, INeedBeSingle
    {
        [SerializeField]
        private float _generationDistance;
        public Transform ThisTransform;
        private Transform _player;
        [Header("Chunks")]
        [SerializeField]
        private Chunk _firstChunk; 
        [SerializeField]
        private Chunk[] _forestChunkPrefabs;
        private Chunk[] _chunksForSpawn;
        private readonly List<Chunk> _spawnedChunks = new List<Chunk>();
        
        private void Start()
        {
            _spawnedChunks.Add(_firstChunk);
            _chunksForSpawn = _forestChunkPrefabs;
            _player = Camera.main.transform;
            ThisTransform = transform;
        }

        private void Update()
        {
            if (!(Vector3.Distance(_spawnedChunks[^1].End.position, _player.position) < _generationDistance)) return;
            SpawnNewChunk();
            DestroyFartherChunk();
        }

        private void SpawnNewChunk()
        {
            var newChunk = Instantiate(_chunksForSpawn[Random.Range(0, _chunksForSpawn.Length)], ThisTransform);
            newChunk.RotationPoint.rotation = new Quaternion(0, 180 * Random.Range(0, 2), 0, 0);
            newChunk.transform.position = _spawnedChunks[^1].End.position - newChunk.Begin.localPosition;
            _spawnedChunks.Add(newChunk);
        }

        private void DestroyFartherChunk()
        {
            if (!(Vector3.Distance(_spawnedChunks[0].End.position, _player.position) > _generationDistance)) return;
            Destroy(_spawnedChunks[0].gameObject);
            _spawnedChunks.RemoveAt(0);
        }
    }
}