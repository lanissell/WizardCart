using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] private float destroyTime;
    private void Start()
    {
        Destroy(gameObject,destroyTime);
    }
}
