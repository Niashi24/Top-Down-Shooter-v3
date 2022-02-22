using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    [SerializeField] AudioClip _clip;
    [SerializeField] bool _loop;
    [SerializeField] bool _playOnAwake;
    [SerializeField] float _volume;
    [SerializeField] AudioSource _audioSource;

    void Awake() {
        UpdateAudioSource();
        
        if (_playOnAwake)
            Play();
    }

    void UpdateAudioSource() {
        if (_audioSource == null) _audioSource = gameObject.AddComponent<AudioSource>();
        _audioSource.loop = _loop;
        _audioSource.clip = _clip;
        _audioSource.volume = _volume;
    }

    public void Play() {
        UpdateAudioSource();
        _audioSource.Play();
    }
}
