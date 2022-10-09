using UnityEngine;

namespace chunk
{
    public class ChunksMovement : MonoBehaviour
    {
        [SerializeField]
        private float _moveSpeed;
        private DistanceDependence _distanceDependence;

        private void Start()
        {
            _distanceDependence = Singleton<DistanceDependence>.Instance;
        }
        private void Update()
        {
            _moveSpeed = _distanceDependence.MoveSpeed;
            transform.Translate(-transform.forward * (Time.deltaTime * _moveSpeed));
        }
    }
}
