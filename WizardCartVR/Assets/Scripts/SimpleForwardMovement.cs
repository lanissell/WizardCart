using System;
using UnityEngine;

public class SimpleForwardMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private void Update()
    {
        transform.position += transform.forward * (speed * Time.deltaTime);
    }
}