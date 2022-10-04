using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class KnifeSpawner : MonoBehaviour
{
    public GameObject Prefab;
    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            Instantiate(Prefab, transform.position, quaternion.identity);
        }
    }
}
