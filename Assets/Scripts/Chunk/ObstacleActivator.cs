using UnityEngine;

namespace Chunk
{
    [RequireComponent(typeof(Animator),typeof(SphereCollider), typeof(AudioSource))]
    public class ObstacleActivator : MonoBehaviour
    {
        [SerializeField]
        private AudioClip[] _activateSounds;
        [SerializeField]
        private float _minDistanceToActivate;
        [SerializeField]
        private float _maxDistanceToActivate;
        private Animator _animator;
        private SphereCollider _collider;
        private DistanceDependence _distanceDependence;
        private AudioSource _audioSource;
        private void Start()
        {
            _distanceDependence = Singleton<DistanceDependence>.Instance;
            if (!(Random.value < _distanceDependence.ChanceOfActivateObstacle)) Destroy(this);
            _animator = GetComponent<Animator>();
            _collider = GetComponent<SphereCollider>();
            _audioSource = GetComponent<AudioSource>();
            _collider.radius = Random.Range(_minDistanceToActivate, _maxDistanceToActivate);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out Player _)) return;
            _animator.enabled = true;
            _audioSource.PlayOneShot(_activateSounds[Random.Range(0, _activateSounds.Length)]);
        }

    }
}
