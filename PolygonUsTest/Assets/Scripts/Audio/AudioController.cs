using UnityEngine;
using UnityEngine.Audio;

namespace Polygonus
{
    public class AudioController : MonoBehaviour
    {
        public static AudioController instance;

        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private AudioSource _audioSourceSFX;
        [SerializeField] private AudioSource _audioSourceMusic;

        private void Awake() => instance = this;

        public void PlaySFX(AudioClip audio)
        {
            _audioSourceSFX.clip = audio;
            _audioSourceSFX.loop = false;
            _audioSourceSFX.Play();
        }

        public void PlayMusic(AudioClip audio)
        {
            _audioSourceMusic.clip = audio;
            _audioSourceMusic.loop = true;
            _audioSourceMusic.Play();
        }
    }

    public enum AudioType
    {
        SFX,
        Music
    }
}
