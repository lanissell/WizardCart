using UnityEngine;
namespace chunk
{
    public class SelectRandom : MonoBehaviour
    {
        [SerializeField]
        private int _countToLeave = 1;

        private void Start()
        {
            while (transform.childCount > _countToLeave)
            {
                Transform childToDestroy = transform.GetChild(Random.Range(0, transform.childCount));
                DestroyImmediate(childToDestroy.gameObject);
            }
        }
    }
}
