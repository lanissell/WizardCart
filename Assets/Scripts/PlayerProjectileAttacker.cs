using System.Collections;
using UnityEngine;

public class PlayerProjectileAttacker : MonoBehaviour
{
    [SerializeField]
    private float _timeToFall;
    [SerializeField]
    private GameObject _projectilePrefab;
    private GameObject _projectile;

    public void Attack(string gestureName)
    {
        if (gestureName.Equals("Circle"))
        {  
            _projectile = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
        }
        if (_projectile == null) return;
        StartCoroutine(Fall());
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(_timeToFall);
        if (!_projectile.TryGetComponent(out Rigidbody rb)) yield break;
        if (rb.isKinematic) rb.isKinematic = false;
    }

}
