using UnityEngine;

namespace enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] enemyPrefabs;
        private void Start()
        {
            Instantiate(enemyPrefabs[Random.Range(0,enemyPrefabs.Length)], transform.GetChild(0));
        }
    }
}
