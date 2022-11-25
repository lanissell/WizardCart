using UnityEngine;

namespace Enemy
{
    public class Wizard : MonoBehaviour
    {
        private Vector3 _targetPosition;

        private void Start()
        {
            _targetPosition = Camera.main.transform.position;
            GlobalEventManager.OnEnemyDie += Die;
        }

        private void Update()
        {
            transform.LookAt(new Vector3(_targetPosition.x, 0, _targetPosition.z));
        }

        private void Die(Transform diedTransform)
        {
            if (diedTransform != transform) return;
            GlobalEventManager.OnEnemyDie -= Die;
            Destroy(this);
        }
    }
}