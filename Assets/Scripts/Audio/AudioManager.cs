using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager I {get; private set;}

    [SerializeField] List<SoundClip> clips;

    Dictionary<SoundClip, AudioSource> dictionary = new Dictionary<SoundClip, AudioSource>();

    void Awake() {
        if (I != null) {
            Destroy(gameObject);
            return;
        }

        I = this;
        foreach (var clip in clips) {
            dictionary[clip] = gameObject.AddComponent<AudioSource>();
        }
    }

    void OnDestroy() {
        if (I == this) I = null;   
    }

    public void PlaySound(SoundClip clip) {
        if (dictionary.ContainsKey(clip)) {
            var source = dictionary[clip];

            source.volume = clip.Volume;
            source.loop = clip.Loop;
            source.clip = clip.Clip;

            source.Play();
        } else {
            dictionary[clip] = gameObject.AddComponent<AudioSource>();
        }
    }
}
