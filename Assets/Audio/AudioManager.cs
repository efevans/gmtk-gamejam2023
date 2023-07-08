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

    public void PlayClip(AudioClip clip)
    {
        AudioSource.clip = clip;
        AudioSource.loop = true;
        AudioSource.Play();
    }
}
