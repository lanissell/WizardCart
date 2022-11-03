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

        private void Start()
        {
            _distanceDependence = Singleton<DistanceDependence>.Instance;
            _transform = transform;
            _movementDirection = -_transform.forward;
        }
        private void Update()
        {
            _moveSpeed = _distanceDependence.MoveSpeed;
            _transform.Translate(_movementDirection * (Time.deltaTime * _moveSpeed));
        }
    }
}
