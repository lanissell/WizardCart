using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace cart
{
    public class WheelRotator : MonoBehaviour
    {
        [FormerlySerializedAs("wheelRotateSpeed")] [SerializeField]
        private float _wheelRotateSpeed;
        [FormerlySerializedAs("wheelsModelParent")] [SerializeField]
        private Transform _wheelsModelParent;
        private Transform[] _wheelsModels;
        private RotateWheelDelegate _rotateWheel;

        private void Start()
        {
            _wheelsModels = _wheelsModelParent.GetComponentsInChildren<Transform>();
            GlobalEventManager.OnRunStart += ActivateRotation;
        }

        private void Update()
        {
            _rotateWheel?.Invoke();
        }

        private void RotateWheel()
        {
            foreach (var wheel in _wheelsModels) 
                wheel.Rotate(new Vector3(wheel.localPosition.x,0,0), _wheelRotateSpeed * Time.deltaTime) ;
        }

        private void ActivateRotation()
        {
            GlobalEventManager.OnRunStart -= ActivateRotation;
            _rotateWheel = RotateWheel;
        }

        private delegate void RotateWheelDelegate();
    }
}
