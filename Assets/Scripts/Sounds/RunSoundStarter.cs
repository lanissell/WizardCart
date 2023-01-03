using UnityEngine;
namespace Sounds
{
    [RequireComponent(typeof(AudioSource))]
    public class RunSoundStarter : MonoBehaviour
    {
        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            RunStarter.OnRunStarted += PlaySound;
        }

        private void PlaySound()
        {
            RunStarter.OnRunStarted -= PlaySound;
            _audioSource.Play();
        }
    }
}
