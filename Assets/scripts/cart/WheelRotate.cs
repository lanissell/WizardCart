using UnityEngine;

namespace cart
{
    public class WheelRotate : MonoBehaviour
    {
        [SerializeField]
        private float wheelRotateSpeed;
        [SerializeField]
        private Transform wheelsModelParent;
        private Transform[] _wheelsModels;

        private void Start()
        {
            _wheelsModels = wheelsModelParent.GetComponentsInChildren<Transform>();
        }

        private void Update()
        {
            foreach (Transform wheel in _wheelsModels) wheel.Rotate(new Vector3(wheel.localPosition.x,0,0), wheelRotateSpeed * Time.deltaTime) ;
        }
    }
}
