using System;
using Enemy;
using ProjectilesAndParticles;
using UnityEngine;
using Weapons;

public class RunStarter : MonoBehaviour, IWeaponVisitor
{
    public static event Action OnRunStarted; 

    private void StartRun()
    {
        OnRunStarted?.Invoke();
        Destroy(this);
    }
    
    public void Visit(Sharp sharp)
    {
        StartRun();
    }
    
    public void Visit(FireBall fireBall)
    {
        StartRun();
    }
}
