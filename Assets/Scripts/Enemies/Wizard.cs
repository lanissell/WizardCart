using enemy;
using UnityEngine;

namespace Enemies
{
    public class Wizard : Enemy
    {
        private Vector3 _targetPosition;
        
        private void Start()
        {
            _targetPosition = Camera.main.transform.position;
            EnemyLimb.OnLimbCollideWithWeapon += Die;
        }

        private void Update()
        {
            transform.LookAt(new Vector3(_targetPosition.x, 0, _targetPosition.z));
        }

        protected override void Die(Transform diedTransform)
        {
            if (diedTransform != transform) return;
            base.Die(diedTransform);
            EnemyLimb.OnLimbCollideWithWeapon -= Die;
            Destroy(this);
        }
    }
}