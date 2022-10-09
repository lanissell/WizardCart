using UnityEngine;
public class EnemySpawnController : MonoBehaviour, INeedBeSingle
{
    public GameObject[] EnemyPrefabs;
    public Transform EnemyParent;    
    [SerializeField]
    private float _enemySpawnDelay;
    private float _spawnStartTime;
    private void Start()
    {
        _spawnStartTime = Time.time - _enemySpawnDelay;
    }
        
    public bool CheckSpawnPossibility()
    {
        if (!(Time.time - _spawnStartTime >= _enemySpawnDelay)) return false;
        _spawnStartTime = Time.time;
        return true;
    }
}