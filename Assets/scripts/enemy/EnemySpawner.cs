using UnityEngine;

namespace enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        private EnemySpawnController _gameManager;
        private GameObject[] _enemyPrefabs;
        private void Start()
        {
            _gameManager = Singleton<EnemySpawnController>.Instance;
            _enemyPrefabs = _gameManager.EnemyPrefabs;
            if (_enemyPrefabs == null || _enemyPrefabs.Length == 0) return;
            if (!_gameManager.CheckSpawnPossibility())
            {
                Destroy(gameObject);
                return;
            }
            Transform enemyParent = _gameManager.EnemyParent;
            Vector3 position = transform.GetChild(0).position;
            Instantiate(_enemyPrefabs[Random.Range(0,_enemyPrefabs.Length)], position, Quaternion.identity, enemyParent);
        }
    }
}
