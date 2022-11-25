using UnityEngine;

namespace Sounds
{
    public class PitchRandomizer : MonoBehaviour
    {
        [Range(-3,1f)]
        [SerializeField]
        private float _minPitch;
        [Range(1,3)]
        [SerializeField]
        private float _maxPitch;
        [SerializeField]
        private AudioSource[] _audioSources;
    
        private void Start()
        {
            if (_audioSources.Length == 0) return;
            foreach (AudioSource audioSource in _audioSources)
            {
                audioSource.pitch = Random.Range(_minPitch, _maxPitch);
            }
        }

    }
}
