using UnityEngine;

namespace chunk
{
    public class ChunksMovement : MonoBehaviour
    {
        [SerializeField]
        private float _moveSpeed;
        [SerializeField]
        private AnimationCurve _speedFromDistance;
        private GameManager _gameManager;

        private void Start()
        {
            _gameManager = GameManager.Instance;
        }
        private void Update()
        {
            _moveSpeed = _speedFromDistance.Evaluate( _gameManager.TotalDistance);
            transform.Translate(-transform.forward * (Time.deltaTime * _moveSpeed));
        }
    }
}
