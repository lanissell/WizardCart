using UnityEngine;

namespace enemy.wizard
{
    public class IceShard : MonoBehaviour, IProjectile
    {
        private ParticleSystem _particleSystem;
        [SerializeField] 
        private ParticleSystem _chargeEffect;
        private void Start()
        {
            _particleSystem = GetComponent<ParticleSystem>();
            Destroy(Instantiate(_chargeEffect,transform), 3f);
        }
        
        public void Throw(Vector3 targetPosition)
        {
            _particleSystem.Play();
            transform.parent = null;
        }
        
    }
}
