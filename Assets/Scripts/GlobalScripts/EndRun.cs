using Chunk;
using Save;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndRun : MonoBehaviour
{
    private DistanceDependence _distanceDependence;
    
    private void Start()
    {
        HittingPlayer.OnPlayerHitted += EndRound;
        _distanceDependence = Singleton<DistanceDependence>.Instance;
    }

    private void EndRound()
    {
        SaveScore();
        HittingPlayer.OnPlayerHitted -= EndRound;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void SaveScore()
    {
        var data = BinarySaveSystem.Load();
        data.LastScore = (int)_distanceDependence.TotalDistance;
        BinarySaveSystem.Save(data);
    }

}
