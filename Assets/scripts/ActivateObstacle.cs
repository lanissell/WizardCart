using System.Collections;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class ActivateObstacle : MonoBehaviour
{
    private GameManager _score;
    private float _distanceToActivate;
    private float _distance;
    private Transform _player;
    private Animator _animator;
    
    private void Start()
    {
        _score = GameManager.Instance;
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _animator = GetComponent<Animator>();
        _distanceToActivate = _score.distanceToActivateObstacle;
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
