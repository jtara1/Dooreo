using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEditor.SceneManagement;
using UnityEngine;

public class MultiAudioSource : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClips;

    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
    }

    public void PlayRandom()
    {
        int randomIndex = Random.Range(0, audioClips.Length - 1);
        _audioSource.PlayOneShot(audioClips[randomIndex], 2f);
    }
}
