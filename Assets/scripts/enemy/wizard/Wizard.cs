using chunk;
using UnityEngine;

namespace enemy.wizard
{
    [RequireComponent(typeof(Ragdoll), typeof(ProjectileAttacker))]
    public class Wizard : MonoBehaviour
    {
        [SerializeField]
        private float _vewDist;
        private ProjectileAttacker _attacker;
        private Transform _target;
        private Ragdoll _activateRagdoll;
        private ChunksPlacer _chunksPlacer;
        private void Start()
        {
            _chunksPlacer = Singleton<ChunksPlacer>.Instance;
            _activateRagdoll = GetComponent<Ragdoll>();
            _attacker = GetComponent<ProjectileAttacker>();
            _target = Camera.main.transform;
            _activateRagdoll.OnRagdollActive += DestroyWizardScript;
        }

        private void Update()
        {
            float dist = Vector3.Distance(transform.position, _target.position);
            if (dist >= _chunksPlacer._generationDistance * 1.5f) Destroy(gameObject);
            if (dist > _vewDist) return;
            Vector3 position = _target.position;
            transform.LookAt(new Vector3(position.x, 0, position.z));
            _attacker.StartAttackCoroutine(dist, _target);
        }
        

        private void DestroyWizardScript()
        {
            _activateRagdoll.OnRagdollActive -= DestroyWizardScript;
            Destroy(this);
            Destroy(_attacker);
            Destroy(_activateRagdoll);
        }
    }
}