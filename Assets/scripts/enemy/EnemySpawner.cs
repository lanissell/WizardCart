using UnityEngine;

namespace enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        private EnemySpawnController _spawnController;
        private GameObject[] _enemyPrefabs;

        private void Start()
        {
            _spawnController = Singleton<EnemySpawnController>.Instance;
            _enemyPrefabs = _spawnController.EnemyPrefabs;

            if (_enemyPrefabs == null || _enemyPrefabs.Length == 0) return;
            if (!_spawnController.CheckSpawnPossibility())
            {
                Destroy(gameObject);
                return;
            }
            SpawnEnemy();
        }

        private void SpawnEnemy()
        {
            Vector3 position = transform.GetChild(0).position;
            Instantiate(_enemyPrefabs[Random.Range(0,_enemyPrefabs.Length)], position, Quaternion.identity, transform);
        }
    }
}
