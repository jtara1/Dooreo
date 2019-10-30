using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEditor.SceneManagement;
using UnityEngine;

public class MultiAudioSource : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClips;

    private AudioSource _audioSource;

    public AudioSource AudioSource => _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
    }

    public void PlayRandom(float volume = 1f)
    {
        _audioSource.PlayOneShot(GetRandomClip(), volume);
    }

    public AudioClip GetRandomClip()
    {
        int randomIndex = Random.Range(0, audioClips.Length - 1);
        return audioClips[randomIndex];
    }
}
