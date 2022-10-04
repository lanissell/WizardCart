using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] 
    private float _destroyTime;
    private void Start()
    {
        Destroy(gameObject,_destroyTime);
    }
}
