using System.Collections;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class ActivateObstacle : MonoBehaviour
{
    [Tooltip("Distance set random from min value to (min * 2)")]
    [SerializeField]
    private float minDistanceToActivate;
    private float _distanceToActivate;
    private float _distance;
    private Transform _player;
    private Animator _animator;
    
    private void Start()
    {
        if (Camera.main != null) _player = Camera.main.transform;
        _animator = GetComponent<Animator>();
        _distanceToActivate = Random.Range(minDistanceToActivate, minDistanceToActivate * 2);
        _distance = Vector3.Distance(transform.position, _player.position);
        StartCoroutine(ActivateObstacleAnimator());     
    }

    private IEnumerator ActivateObstacleAnimator() 
    {
        while (_distance > _distanceToActivate) 
        {
            _distance = Vector3.Distance(transform.position, _player.position);
            yield return new WaitForSeconds(2);
        } 
        _animator.enabled = true;
    }
}
