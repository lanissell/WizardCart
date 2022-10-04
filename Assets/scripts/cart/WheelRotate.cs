using UnityEngine;
using UnityEngine.Serialization;

namespace cart
{
    public class WheelRotate : MonoBehaviour
    {
        [FormerlySerializedAs("wheelRotateSpeed")] [SerializeField]
        private float _wheelRotateSpeed;
        [FormerlySerializedAs("wheelsModelParent")] [SerializeField]
        private Transform _wheelsModelParent;
        private Transform[] _wheelsModels;

        private void Start()
        {
            _wheelsModels = _wheelsModelParent.GetComponentsInChildren<Transform>();
        }

        private void Update()
        {
            foreach (var wheel in _wheelsModels) 
                wheel.Rotate(new Vector3(wheel.localPosition.x,0,0), _wheelRotateSpeed * Time.deltaTime) ;
        }
    }
}
