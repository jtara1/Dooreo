using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource _audioSource;

    private void Start()
    {
        Instance = this;
        _audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void PlayOneShot(AudioClip clip, float volume)
    {
        _audioSource.PlayOneShot(clip, volume);
    }
}
