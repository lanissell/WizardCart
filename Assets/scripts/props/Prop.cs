using System;
using chunk;
using UnityEngine;

namespace props
{
    [RequireComponent (typeof(Rigidbody))]
    public class Prop: MonoBehaviour
    {
        private GameObject _chunkPlacer;
        private Rigidbody _rigidbody;
        private void Start()
        {
            _chunkPlacer = ChunksPlacer.Instance.gameObject;
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (transform.position.y < -15) Destroy(gameObject);
        }

        public void SetRigidbodyIsKinematicFalse()
        {
            _rigidbody.isKinematic = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("ground"))
            {
                transform.parent = _chunkPlacer.transform;
            }
        }
    }
}
