using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Smartphone : MonoBehaviour
{
    [SerializeField]
    private Image _screen; 

    [SerializeField]
    private TextMeshProUGUI _title;

    [SerializeField]
    private Image _uploaderImage;

    [SerializeField]
    private TextMeshProUGUI _uploaderName;

    private AudioManager _audioManager;

    [Inject]
    public void Construct(AudioManager audioManager)
    {
        _audioManager = audioManager;
    }

    public void SetPlayingVideo(Video video)
    {
        _screen.sprite = video.VideoImage;
        _screen.color = Color.white;
        _title.text = video.Title;
        _uploaderImage.sprite = video.UploaderImage;
        _uploaderImage.color = Color.white;
        _uploaderName.text = video.UploaderName;

        _audioManager.PlayClip(video.Audio);
    }
}
