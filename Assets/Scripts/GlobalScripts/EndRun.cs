using Chunk;
using Save;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndRun : MonoBehaviour
{
    private DistanceDependence _distanceDependence;
    
    private void Start()
    {
        GlobalEventManager.OnEnemyHit += EndRound;
        _distanceDependence = Singleton<DistanceDependence>.Instance;
    }

    private void EndRound()
    {
        SaveScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void SaveScore()
    {
        var data = BinarySaveSystem.Load();
        data.LastScore = (int)_distanceDependence.TotalDistance;
        BinarySaveSystem.Save(data);
    }

    private void OnTriggerEnter(Collider other)
    {
        var parent = other.transform.parent;
        if (parent == null) return;
        if (parent.TryGetComponent(out ObstacleActivator _))
        {
            EndRound();
        }
    }

}
