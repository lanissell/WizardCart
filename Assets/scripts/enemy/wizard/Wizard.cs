using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace enemy.wizard
{
    [RequireComponent(typeof(ActivateRagdoll), typeof(ProjectileAttacker))]
    public class Wizard : MonoBehaviour
    {
        [SerializeField]
        private float vewDist;

        private ProjectileAttacker _attacker;
        private Transform _target;
        private ActivateRagdoll activateRagdoll;
        private void Start()
        {
            
            activateRagdoll = GetComponent<ActivateRagdoll>();
            activateRagdoll.OnRagdollActive += DestroyWizardScript;
            _target = GameObject.FindWithTag("Player").transform;
            _attacker = GetComponent<ProjectileAttacker>();
        }

        private void Update()
        {
            var dist = Vector3.Distance(transform.position, _target.position);
            if (!(dist < vewDist)) return;
            var position = _target.position;
            transform.LookAt(new Vector3(position.x, 0, position.z));
            _attacker.StartAttack(dist, _target);
        }
        

        private void DestroyWizardScript()
        {
            Destroy(gameObject.GetComponent<Wizard>());
            Destroy(_attacker);
            Destroy(activateRagdoll);
        }
    }
}