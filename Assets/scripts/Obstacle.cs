using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Animator),typeof(SphereCollider))]
public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private float _minDistanceToActivate;
    [SerializeField]
    private float _maxDistanceToActivate;
    private float _distance;
    private Animator _animator;
    private SphereCollider _collider;
    private GameManager _gameManager;
    private void Start()
    {
        _gameManager = GameManager.Instance;
        if (!(Random.value < _gameManager._chanceOfActivateObstacle)) Destroy(this);
        _animator = GetComponent<Animator>();
        _collider = GetComponent<SphereCollider>();
        _collider.radius = Random.Range(_minDistanceToActivate, _maxDistanceToActivate);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera")) _animator.enabled = true;
    }
    
}
