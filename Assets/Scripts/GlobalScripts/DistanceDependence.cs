using chunk;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
public class DistanceDependence : MonoBehaviour, INeedBeSingle
{
    public float TotalDistance;
    [Header("Value from distance")]
    [HideInInspector]
    public float ChanceOfActivateObstacle;
    [HideInInspector]
    public float MoveSpeed;
    [SerializeField]
    private AnimationCurve _chanceOfActivateObstacleFromDistance;
    [SerializeField]
    private AnimationCurve _speedFromDistance;
    private ChunksPlacer _chunksPlacer;

    [SerializeField]
    private TextMeshProUGUI _scoreText;
    private void Start()
    {
        _chunksPlacer = Singleton<ChunksPlacer>.Instance;
    }

    private void Update()
    {
        TotalDistance = -_chunksPlacer.ThisTransform.position.z;
        CurvesEvaluate();
        _scoreText.text = $"{Mathf.RoundToInt(TotalDistance)}";
    }

    private void CurvesEvaluate()
    {
        ChanceOfActivateObstacle = _chanceOfActivateObstacleFromDistance.Evaluate(TotalDistance);
        MoveSpeed = _speedFromDistance.Evaluate(TotalDistance);
    }
    
}