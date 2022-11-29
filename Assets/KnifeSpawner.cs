using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class KnifeSpawner : MonoBehaviour
{
    [SerializeField]
    private float _maxCount;
    [SerializeField]
    private GameObject _prefab;
    
    private IEnumerator Start()
    {
        Transform thisTransform = transform;
        while (true)
        {
            yield return new WaitForSeconds(5);
            if (thisTransform.childCount < _maxCount) 
                Instantiate(_prefab, thisTransform.position, quaternion.identity, thisTransform);
        }
    }
}
