using UnityEngine;
using UnityEngine.SceneManagement;

public class EndRun : MonoBehaviour
{
    private static void EndRound()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("obstacle") || other.CompareTag("fireBall"))
        {
            EndRound();
        }
    }

}
