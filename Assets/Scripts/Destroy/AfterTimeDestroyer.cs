using UnityEngine;
namespace Destroy
{
    public class AfterTimeDestroyer : MonoBehaviour
    {
        [SerializeField] 
        private float _destroyTime;
        private void Start()
        {
            Destroy(gameObject, _destroyTime);
        }
    }
}
