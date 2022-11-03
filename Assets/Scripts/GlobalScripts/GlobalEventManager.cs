using System;

public static class GlobalEventManager
{
        public static event Action OnEnemyHit;

        public static void SendOnPlayerHit() => OnEnemyHit?.Invoke();
}