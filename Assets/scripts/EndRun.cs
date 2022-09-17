using System;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("obstacle"))
        {
            EndRound();
        }
    }

}
