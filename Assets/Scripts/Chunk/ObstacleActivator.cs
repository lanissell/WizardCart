using UnityEngine;

namespace Chunk
{
    [RequireComponent(typeof(Animator),typeof(SphereCollider))]
    public class ObstacleActivator : MonoBehaviour
    {
        [SerializeField]
        private float _minDistanceToActivate;
        [SerializeField]
        private float _maxDistanceToActivate;
        private Animator _animator;
        private SphereCollider _collider;
        private DistanceDependence _distanceDependence;
        private void Start()
        {
            _distanceDependence = Singleton<DistanceDependence>.Instance;
            if (!(Random.value < _distanceDependence.ChanceOfActivateObstacle)) Destroy(this);
            _animator = GetComponent<Animator>();
            _collider = GetComponent<SphereCollider>();
            _collider.radius = Random.Range(_minDistanceToActivate, _maxDistanceToActivate);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player _)) _animator.enabled = true;
        }

    }
}
