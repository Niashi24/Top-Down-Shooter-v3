using UnityEngine;

[CreateAssetMenu]
public class SoundClip : ScriptableObject {
    [SerializeField] AudioClip _clip;
    public AudioClip Clip => _clip;
    [SerializeField] bool _loop;
    public bool Loop => _loop;
    [SerializeField] float _volume;
    public float Volume => _volume;
}