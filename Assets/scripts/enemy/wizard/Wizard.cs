using System.Collections;
using chunk;
using UnityEngine;
using Random = UnityEngine.Random;

namespace enemy.wizard
{
    [RequireComponent(typeof(Ragdoll), typeof(ProjectileAttacker))]
    public class Wizard : MonoBehaviour
    {
        [SerializeField]
        private float vewDist;
        private ProjectileAttacker _attacker;
        private Transform _target;
        private Ragdoll activateRagdoll;
        private ChunksPlacer _chunksPlacer;
        private void Start()
        {
            _chunksPlacer = ChunksPlacer.Instance;
            activateRagdoll = GetComponent<Ragdoll>();
            activateRagdoll.OnRagdollActive += DestroyWizardScript;
            if (Camera.main != null) _target = Camera.main.transform;
            _attacker = GetComponent<ProjectileAttacker>();
        }

        private void Update()
        {
            var dist = Vector3.Distance(transform.position, _target.position);
            if (dist>=_chunksPlacer.GenerationDistance * 1.5f) Destroy(gameObject);
            if (!(dist < vewDist)) return;
            var position = _target.position;
            transform.LookAt(new Vector3(position.x, 0, position.z));
            _attacker.StartAttackCoroutine(dist, _target);
        }
        

        private void DestroyWizardScript()
        {
            Destroy(gameObject.GetComponent<Wizard>());
            Destroy(_attacker);
            Destroy(activateRagdoll);
        }
    }
}