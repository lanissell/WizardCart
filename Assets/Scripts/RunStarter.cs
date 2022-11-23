using UnityEngine;

public class RunStarter : MonoBehaviour
{
    public void StartRun()
    {
        GlobalEventManager.SendOnRunStart();
        Destroy(this);
    }
}
