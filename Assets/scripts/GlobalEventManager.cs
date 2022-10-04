using System;
using UnityEngine;

public static class GlobalEventManager
{
        public static event Action OnPlayerHit;
        
        public static void SendOnPlayerHit() => OnPlayerHit?.Invoke();
}