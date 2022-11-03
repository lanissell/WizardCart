using System;
using chunk;
using UnityEngine;

namespace props
{
    [RequireComponent (typeof(Rigidbody))]
    public class Prop: MonoBehaviour
    {
        private ChunksPlacer _chunkPlacer;
        private Rigidbody _rigidbody;
        private Transform _transform;
        private void Start()
        {
            _chunkPlacer = Singleton<ChunksPlacer>.Instance;
            _rigidbody = GetComponent<Rigidbody>();
            _transform = transform;
        }

        private void Update()
        {
            if (_transform.position.y < -15) Destroy(gameObject);
        }

        public void SetRigidbodyIsKinematicFalse()
        {
            _rigidbody.isKinematic = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("ground"))
            {
                _transform.parent = _chunkPlacer.ThisTransform;
            }
        }
    }
}
