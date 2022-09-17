using UnityEngine;

namespace enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        private GameManager _gameManager;
        private GameObject[] enemyPrefabs;
        private void Start()
        {
            _gameManager = GameManager.Instance;
            if (!_gameManager.CheckEnemySpawnDelay()) return;
            enemyPrefabs = _gameManager.EnemyPrefabs;
            var enemyParent = _gameManager.EnemyParent;
            var position = transform.GetChild(0).position;
            var rotation = transform.GetChild(0).rotation;
            Instantiate(enemyPrefabs[Random.Range(0,enemyPrefabs.Length)], position,rotation,enemyParent);
        }
    }
}
