using System.Collections;
using System.Collections.Generic;
using chunk;
using UnityEngine;
[RequireComponent (typeof(Rigidbody))]
public class Props : MonoBehaviour
{
    private GameObject _chunkPlacer;
    public bool isGrab = false;
    private void Start()
    {
        _chunkPlacer = ChunksPlacer.Instance.gameObject;
    }

    public void SetGrabTrue()
    {
        isGrab = true;
    }

    public void SetGrabFalse()
    {
        isGrab = false;
        transform.parent = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isGrab)
        {
            if (other.CompareTag("ground"))
            {
                transform.parent = _chunkPlacer.transform;
            }    
        }
    }
}
