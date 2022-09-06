using UnityEngine;

public class SelectRandom : MonoBehaviour
{
    [SerializeField]
    private int countToLeave = 1;
    private GameManager _score;

    private void Start()
    {
        _score = GameManager.Instance;
        while (transform.childCount > countToLeave)
        {
            Transform childToDestroy = transform.GetChild(Random.Range(0, transform.childCount));
            DestroyImmediate(childToDestroy.gameObject);
        }
    }
}
