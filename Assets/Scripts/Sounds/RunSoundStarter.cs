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
            GlobalEventManager.OnRunStart += PlaySound;
        }

        private void PlaySound()
        {
            GlobalEventManager.OnRunStart -= PlaySound;
            _audioSource.Play();
        }
    }
}
