using UnityEngine;

namespace enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        private GameManager _gameManager;
        private GameObject[] _enemyPrefabs;
        private void Start()
        {
            _gameManager = GameManager.Instance;
            if (!_gameManager.CheckSpawnPossibility()) return;
            _enemyPrefabs = _gameManager.EnemyPrefabs;
            Transform enemyParent = _gameManager.EnemyParent;
            Vector3 position = transform.GetChild(0).position;
            Instantiate(_enemyPrefabs[Random.Range(0,_enemyPrefabs.Length)], position, Quaternion.identity, enemyParent);
        }
    }
}
