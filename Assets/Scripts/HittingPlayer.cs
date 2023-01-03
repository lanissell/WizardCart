using System;
using UnityEngine;

public abstract class HittingPlayer: MonoBehaviour
{
       public static event Action OnPlayerHitted;

       protected void HitPlayer()
       { 
              OnPlayerHitted?.Invoke();
       }
}