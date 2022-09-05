using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndRun : MonoBehaviour
{
    public void EndRound()
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
