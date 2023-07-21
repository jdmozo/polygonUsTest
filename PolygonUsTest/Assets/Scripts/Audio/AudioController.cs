using UnityEngine;
using UnityEngine.Audio;

namespace Polygonus
{
    public class AudioController : MonoBehaviour
    {
        public static AudioController instance;

        [SerializeField] private AudioMixer _audioMixer;

        private void Awake() => instance = this;

        public void PlaySFX()
        {

        }

        public void PlayMusic()
        {

        }
    }

    public enum AudioType
    {
        SFX,
        Music
    }
}
