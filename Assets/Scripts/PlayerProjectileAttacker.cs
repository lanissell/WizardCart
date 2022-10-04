using System.Collections;
using enemy;
using UnityEngine;

public class PlayerProjectileAttacker : MonoBehaviour
{
    [SerializeField]
    private GameObject _projectilePrefab;


    public void Attack(string gestureName)
    {
        if (gestureName.Equals("Circle"))
        {  
            Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
        }
    }
    


}
