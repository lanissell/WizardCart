﻿using UnityEngine;

namespace chunk
{
    public class ChunksMovement : MonoBehaviour
    {
        [SerializeField]
        private float _moveSpeed;
        private DistanceDependence _distanceDependence;
        private Vector3 _movementDirection;
        private Transform _transform;
        private ChunkMoveDelegate _chunkMoveDelegate;

        private void Start()
        {
            _distanceDependence = Singleton<DistanceDependence>.Instance;
            _transform = transform;
            _movementDirection = -_transform.forward;
            RunStarter.OnRunStarted += ActivateChunkMovement;
        }
        private void FixedUpdate()
        {
            _chunkMoveDelegate?.Invoke();
        }

        private void MoveChunk()
        {
            _moveSpeed = _distanceDependence.MoveSpeed;
            _transform.Translate(_movementDirection * (Time.fixedDeltaTime * _moveSpeed));
        }

        private void ActivateChunkMovement()
        {
            RunStarter.OnRunStarted -= ActivateChunkMovement;
            _chunkMoveDelegate = MoveChunk;
        }

        private delegate void ChunkMoveDelegate();
    }
}
