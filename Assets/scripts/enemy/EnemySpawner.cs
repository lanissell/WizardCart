using UnityEngine;

namespace enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] enemyPrefabs;
        private Transform _enemyParent;
        private void Start()
        {
            _enemyParent = GameObject.FindGameObjectWithTag("enemyParent").transform;
            var child = transform.GetComponentsInChildren<Transform>()[1];
            Instantiate(enemyPrefabs[Random.Range(0,enemyPrefabs.Length)], child.position, child.rotation, _enemyParent);
        }
    }
}
