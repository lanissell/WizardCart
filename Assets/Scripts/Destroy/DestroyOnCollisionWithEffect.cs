using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyOnCollisionWithEffect : MonoBehaviour
{
    [SerializeField]
    private GameObject _effect;
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(_effect, collision.transform.position, quaternion.identity);
        Destroy(gameObject);
    }
}
