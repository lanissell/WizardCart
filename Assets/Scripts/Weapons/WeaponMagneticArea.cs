using System;
using UnityEngine;

namespace Weapons
{
    [RequireComponent(typeof(SphereCollider))]
    public class WeaponMagneticArea : MonoBehaviour
    {
        [SerializeField]
        private float _areaSize;
        private SphereCollider _collider;

        private void Start()
        {
            _collider = GetComponent<SphereCollider>();
            _collider.radius = _areaSize;
        }
    }
}
