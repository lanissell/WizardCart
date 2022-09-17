using chunk;
using UnityEngine;

namespace props
{
    [RequireComponent (typeof(Rigidbody))]
    public class Props : MonoBehaviour
    {
        public bool isGrab = false;
        private Rigidbody _rb;
        private GameObject _chunkPlacer;
        private void Start()
        {
            _chunkPlacer = ChunksPlacer.Instance.gameObject;
            _rb = GetComponent<Rigidbody>();
        }

        public void SetGrabTrue()
        {
            isGrab = true;
            _rb.isKinematic = false;
        }

        public void SetGrabFalse()
        {
            isGrab = false;
            transform.parent = null;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (isGrab) return;
            if (other.CompareTag("ground"))
            {
                transform.parent = _chunkPlacer.transform;
            }
        }
    }
}
