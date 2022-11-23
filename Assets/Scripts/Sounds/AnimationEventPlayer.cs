using UnityEngine;
namespace Sounds
{
    [RequireComponent(typeof(AudioSource))]
    public class AnimationEventPlayer : MonoBehaviour
    {
        [SerializeField]
        private AudioClip _sound;
        private AudioSource _audioSource;
        
        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlaySound()
        {
            _audioSource.PlayOneShot(_sound);
        }
    }
}
