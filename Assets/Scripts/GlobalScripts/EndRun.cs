using Chunk;
using UnityEngine;

public class EndRun : MonoBehaviour
{
    private void Start()
    {
        GlobalEventManager.OnEnemyHit += EndRound;
    }

    private static void EndRound()
    {
        print("hit");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter(Collider other)
    {
        // var parent = other.transform.parent;
        // if (parent == null) return;
        // if (parent.TryGetComponent(out Obstacle _))
        // {
        //     EndRound();
        // }
    }

}
