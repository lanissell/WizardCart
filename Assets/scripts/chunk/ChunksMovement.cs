using UnityEngine;

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
            GlobalEventManager.OnRunStart += ActivateChunkMovement;
        }
        private void FixedUpdate()
        {
            _chunkMoveDelegate?.Invoke();
        }

        private void MoveChunk()
        {
            _moveSpeed = _distanceDependence.MoveSpeed;
            _transform.Translate(_movementDirection * (Time.deltaTime * _moveSpeed));
        }

        private void ActivateChunkMovement()
        {
            GlobalEventManager.OnRunStart -= ActivateChunkMovement;
            _chunkMoveDelegate = MoveChunk;
        }

        private delegate void ChunkMoveDelegate();
    }
}
