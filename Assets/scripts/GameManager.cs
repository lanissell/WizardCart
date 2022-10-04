using chunk;
using TMPro;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject[] EnemyPrefabs;
    public Transform EnemyParent;
    public float TotalDistance;
    [SerializeField]
    private float _enemySpawnDelay;
    private float _spawnStartTime;
    [Header("Value from distance")]
    [SerializeField]
    private AnimationCurve _chanceOfActivateObstacleFromDistance;
    [HideInInspector]
    public float _chanceOfActivateObstacle;
    private ChunksPlacer _chunksPlacer;

    [SerializeField]
    private TextMeshProUGUI _scoreText;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        _spawnStartTime = Time.time - _enemySpawnDelay;
        _chunksPlacer = ChunksPlacer.Instance;
    }

    private void Update()
    {
        TotalDistance = -_chunksPlacer.transform.position.z;
        _chanceOfActivateObstacle = _chanceOfActivateObstacleFromDistance.Evaluate(TotalDistance);
        _scoreText.text = $"{Mathf.RoundToInt(TotalDistance)}";
    }

    public bool CheckSpawnPossibility()
    {
        if (!(Time.time - _spawnStartTime >= _enemySpawnDelay)) return false;
        _spawnStartTime = Time.time;
        return true;
    }


}
