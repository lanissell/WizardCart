using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Projectile_and_particle
{
    [RequireComponent(typeof(ParticleSystem))]
    public class ParticleCollisionSoundPlayer : MonoBehaviour
    {
        [SerializeField]
        private AudioSource[] _audioSources;
        [SerializeField]
        private AudioClip[] _collisionSounds;
        [SerializeField]
        private float _delay;
        private bool _canPlay = true;
        
        private void OnParticleCollision(GameObject other)
        {
            if (!_canPlay) return;
            PlaySound();
        }

        private void PlaySound()
        {
            _audioSources[Random.Range(0, _audioSources.Length)].PlayOneShot(_collisionSounds[Random.Range(0, _collisionSounds.Length)]);
            _canPlay = false;
            StartCoroutine(SoundDelay());
        }
        
        private IEnumerator SoundDelay()
        {
            yield return new WaitForSeconds(_delay);
            _canPlay = true;
        }


    }
}
