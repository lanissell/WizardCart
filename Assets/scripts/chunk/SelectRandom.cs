using UnityEngine;
namespace chunk
{
    public class SelectRandom : MonoBehaviour
    {
        [SerializeField]
        private int _countToLeave = 1;

        private void Start()
        {
            var thisTransform = transform;
            while (thisTransform.childCount > _countToLeave)
            {
                Transform childToDestroy = thisTransform.GetChild(Random.Range(0, thisTransform.childCount));
                DestroyImmediate(childToDestroy.gameObject);
            }
        }
    }
}
