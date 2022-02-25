using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    [SerializeField] SoundClip _soundClip;
    [SerializeField] bool _playOnAwake;
    [SerializeField] AudioSource _audioSource;

    void Awake() {
        UpdateAudioSource();
        
        if (_playOnAwake)
            Play();
    }

    void UpdateAudioSource() {
        if (AudioManager.I != null) return;
        if (_audioSource == null) _audioSource = gameObject.AddComponent<AudioSource>();
        _audioSource.loop = _soundClip.Loop;
        _audioSource.clip = _soundClip.Clip;
        _audioSource.volume = _soundClip.Volume;
    }

    public void Play() {
        if (AudioManager.I != null) {
            AudioManager.I.PlaySound(_soundClip);
        } else {
            UpdateAudioSource();
            _audioSource.Play();
        }
    }
}
