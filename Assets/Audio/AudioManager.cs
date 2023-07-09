using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AudioManager
{
    private AudioSource AudioSource { get; }
    private AudioClip _currentAudioClip;

    public AudioManager(AudioSource audioSource)
    {
        AudioSource = audioSource;
    }

    public void PlayShortClip(AudioClip clip)
    {
        AudioSource.PlayOneShot(clip);
    }

    public void PlayClip(AudioClip clip)
    {
        _currentAudioClip = clip;
        AudioSource.clip = _currentAudioClip;
        AudioSource.loop = true;
        AudioSource.Play();
    }
}
