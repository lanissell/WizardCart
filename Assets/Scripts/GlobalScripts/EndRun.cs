using Chunk;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndRun : MonoBehaviour
{
    private void Start()
    {
        GlobalEventManager.OnPlayerHit += EndRound;
    }

    private static void EndRound()
    {
        print("hit");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReloadScene(string gestureName)
    {
        if (gestureName.Equals("Circle")) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.TryGetComponent(out Obstacle _))
        {
            EndRound();
        }
    }

}
