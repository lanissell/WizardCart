using Enemy;
using Projectile_and_particle;
using UnityEngine;
using Weapons;

public class RunStarter : MonoBehaviour, IWeaponVisitor
{
    public void StartRun()
    {
        GlobalEventManager.SendOnRunStart();
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
