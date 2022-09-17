using chunk;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject[] EnemyPrefabs;
    public Transform EnemyParent; 
    [SerializeField]
    private float enemySpawnDelay;
    private float _spawnStartTime;
    private float _totalDistance;
    [Header("Value from distance")]
    [SerializeField]
    private AnimationCurve speedFromDistance;
    [SerializeField]
    private AnimationCurve chanceOfActivateObstacleFromDistance;
    [HideInInspector]
    public float ChanceOfActivateObstacle;
    [Header("Obstacle activate distance")]
    private ChunksPlacer _chunksPlacer;

    [SerializeField]
    private TextMeshProUGUI scoreText;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        _spawnStartTime = Time.time - enemySpawnDelay;
        _chunksPlacer = ChunksPlacer.Instance;
    }

    private void Update()
    {
        _totalDistance = -_chunksPlacer.transform.position.z;
        ChanceOfActivateObstacle = chanceOfActivateObstacleFromDistance.Evaluate(_totalDistance);
        _chunksPlacer.moveSpeed = speedFromDistance.Evaluate(_totalDistance);
        scoreText.text = $"{Mathf.RoundToInt(_totalDistance)}";
    }

    public bool CheckEnemySpawnDelay()
    {
        if (!(Time.time - _spawnStartTime >= enemySpawnDelay)) return false;
        _spawnStartTime = Time.time;
        return true;
    }


}
