using chunk;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance { get; private set; }
    public float totalDistance;
    [Header("Value from distance")]
    [SerializeField]
    private AnimationCurve speedFromDistance;
    [SerializeField]
    private AnimationCurve chanceOfStayFromDistance;
    public float chanceOfActivateObstacle;
    [Header("Obstacle activate distance")]
    [SerializeField]
    private float maxDistanceToActivateObstacle;
    [SerializeField]
    private float minDistanceToActivateObstacle;
    private ChunksPlacer _chunksPlacer;
    public float distanceToActivateObstacle => Random.Range(minDistanceToActivateObstacle, maxDistanceToActivateObstacle);

    [SerializeField]
    private TextMeshProUGUI scoreText;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        _chunksPlacer = FindObjectOfType<ChunksPlacer>();
    }

    private void Update()
    {
        totalDistance = -_chunksPlacer.transform.position.z;
        chanceOfActivateObstacle = chanceOfStayFromDistance.Evaluate(totalDistance);
        _chunksPlacer.moveSpeed = speedFromDistance.Evaluate(totalDistance);
        scoreText.text = $"{Mathf.RoundToInt(totalDistance)}";
    }

}
